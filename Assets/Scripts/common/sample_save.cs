using UnityEngine;
using System.Collections;

public class sample_save : MonoBehaviour {

    static int[] have_costume = { 1, 0, 0 }; //have=1, 
    static int[] have_stage = { 1, 0, 0 };
    static int[] have_light = { 1, 0, 0 };
    static int max_score = 0;
    static int max_combo = 0;
    static int now_point = 0;
    static char[] now_book = {'　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　'};
    static bool normal_mode = false; //clear=true
    static bool clasic_mode = false;
    static bool uniqe_mode = false;
}
