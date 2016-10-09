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
                            if (obj.name == _obj_name) return true;
                        }
                    }
                }
            }
            return false;
        }


    }
}
