using UnityEngine;
using System.Collections;

public class sample_save : MonoBehaviour {

	public static bool[] have_costume = { true, true, true }; //have=1, 
	public static bool[] have_stage = { true, true, true };
	public static bool[] have_light = { true, true, true };
	public static string now_costume_str;
	public static string now_stage_str;
	public static Color now_color_str;
	public static int max_score = 0;
	public static int max_combo = 0;
	public static int now_point = 0;
	public static char[] now_book = {'　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　'};
	public static int now_book_percent = 0;
	public static bool normal_mode = false; //clear=true
	public static bool clasic_mode = false;
	public static bool uniqe_mode = false;
}
