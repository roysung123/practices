/// @description Insert description here
// You can write your code in this editor
bpm = 93;
note_speed = 1;
judge_range = 0.2;

enum keyset{
	key1,
	key2,
	key3,
	key4,
}
key[keyset.key1] = ord("D");
key[keyset.key2] = ord("F");
key[keyset.key3] = ord("J");
key[keyset.key4] = ord("K");
win_flag = false;
instance_create_layer(192,160,"Instances",oEnemysys);
bgm = noone;
bgm_pos_now = noone;
bgm_length = noone;
bgm_playing_flag = false;
counter = 0;