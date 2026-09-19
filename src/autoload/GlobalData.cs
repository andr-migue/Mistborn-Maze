using Godot;
using System.Collections.Generic;
public partial class GlobalData : Node {
	// Autoload GlobalData para almacenar variables globales.
	public static int Filas;
	public static int Columnas;
	public static int[,] IntBoard;
	public static PackedScene Player1Scene;
	public static PackedScene Player2Scene;
	public static int Score1;
	public static int Score2;
	public static int Traps;
	public static int Fire;
	public static int Teleport;
	public static int Mist;
	public static int Gem;
	public static int Heart;
	public static int Wolf;
	public static int Spectre;
	public static int Skeleton;
	public static int VictoryCondition;
	public static List<string> SongsMenu = new List<string>();
	public static List<string> SongsGame = new List<string>();
	public override void _Ready() {
		// Cargar Lista de Reproduccion del menu
		SongsMenu.Add("res://assets/music/menu/01_main_theme_part_i.mp3");
		SongsMenu.Add("res://assets/music/menu/02_main_theme_part_ii.mp3");
		SongsMenu.Add("res://assets/music/menu/04_who_are_you.mp3");
		SongsMenu.Add("res://assets/music/menu/06_quest_for_a_cure.mp3");
		SongsMenu.Add("res://assets/music/menu/08_harpy_song.mp3");
		SongsMenu.Add("res://assets/music/menu/41_main_theme_part_iii.mp3");
		SongsMenu.Add("res://assets/music/menu/42_i_want_to_live.mp3");
		SongsMenu.Add("res://assets/music/menu/43_the_power_credits_song.mp3");
		// Cargar Lista de Reproduccion del Juego
		SongsGame.Add("res://assets/music/game/03_mind_flayer_theme.mp3");
		SongsGame.Add("res://assets/music/game/05_nine_blades.mp3");
		SongsGame.Add("res://assets/music/game/07_lead_your_fights.mp3");
		SongsGame.Add("res://assets/music/game/26_the_odds_are_cast_anew.mp3");
		SongsGame.Add("res://assets/music/game/31_song_of_balduran.mp3");
		SongsGame.Add("res://assets/music/game/32_the_legacy_of_bhaal.mp3");
		SongsGame.Add("res://assets/music/game/36_raphaels_final_act.mp3");
		SongsGame.Add("res://assets/music/game/37_the_grand_design_requiem.mp3");
		VictoryCondition = 2;
		Filas = 33;
		Columnas = 33;
		Traps = 10;
		Fire = 2;
		Teleport = 1;
		Mist = 3;
		Gem = 3;
		Heart = 2;
		Wolf = 2;
		Skeleton = 7;
		Spectre = 1;
		Score1 = 0;
		Score2 = 0;
		Player1Scene = GD.Load<PackedScene>("res://scenes/characters/rain.tscn");
		Player2Scene = GD.Load<PackedScene>("res://scenes/characters/lasswell.tscn");
		SoundManager.Play(SongsMenu);
	}
}
