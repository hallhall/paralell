using UnityEngine;
using System.Collections;

public class sample_save : MonoBehaviour {

	public static bool[] have_costume = { true, false, false }; //have=1, 
	public static bool[] have_stage = { true, false, false };
	public static bool[] have_light = { true, false, false };
	public static int max_score = 0;
	public static int max_combo = 0;
	public static int now_point = 0;
	public static char[] now_book = {'　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　'};
	public static int now_book_percent = 0;
	public static bool normal_mode = false; //clear=true
	public static bool clasic_mode = false;
	public static bool uniqe_mode = false;
}
