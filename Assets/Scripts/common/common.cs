using UnityEngine;
using System.Collections;

namespace common {

    //共通メソッド
    public static class common_method {

        //タッチされたオブジェクトが指定の名前通りならtrue
        public static bool is_touch(string _obj_name) {
            if (Input.GetMouseButtonDown(0)) {
                Vector3 _aTapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 aTapPoint = _aTapPoint;
                Collider2D[] aCollider2dAll = Physics2D.OverlapPointAll(aTapPoint);
                if (aCollider2dAll.Length > 0) {
                    foreach (Collider2D aCollider2d in aCollider2dAll) {
                        if (aCollider2d) {
                            GameObject obj = aCollider2d.transform.gameObject;
                            //
                            //Debug.Log(obj.name);
                            //
                            if (obj.name == _obj_name) return true;
                        }
                    }
                }
            }
            return false;
        }

        //タッチ判定（３ｄ）
        public static bool is_touch_3d(string _obj_name) {
            if (Input.GetMouseButtonDown(0)) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(ray, out hit)) {
                    GameObject obj = hit.collider.gameObject;
                    //
                    Debug.Log(obj.name);
                    //
                    if (_obj_name == obj.name) return true;
                }
            }
            return false;
        }


        //タッチ判定（複数、返り値は成功すれば文字列。失敗すれば空文字）
        public static string is_touch_3d_str(string[] _objs_name) {
            if (Input.GetMouseButtonDown(0)) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(ray, out hit)) {
                    GameObject obj = hit.collider.gameObject;
                    //
                    //Debug.Log(obj.name);
                    //
                    foreach (string _obj_name in _objs_name) {
                        if (_obj_name == obj.name) return _obj_name;
                    }
                }
            }
            return "";
        }
    }
}
