/// @description Insert description here
// You can write your code in this editor
if(counter>room_speed*60/oMainsys.bpm*(1+note_speed)&&!bgm_playing_flag){
	bgm = audio_play_sound(forest_of_the_spirit,1,false);
	bgm_pos_now = audio_sound_get_track_position(bgm);
	bgm_length = audio_sound_length(bgm);
	bgm_playing_flag = true;
}
if(bgm_playing_flag){
	if(audio_sound_get_track_position(bgm)>64){
		audio_stop_sound(bgm);
	}
	if(!audio_is_playing(bgm)){
		global.win_flag = true;
		room_goto(rMenu);
	}
	if(!instance_exists(oEnemysys)){
		global.win_flag = true;
		room_goto(rMenu);
		//audio_stop_sound(forest_of_the_spirit);
	}
	if(oPlayersys.hp <= 0){
		global.win_flag = false;
		audio_stop_sound(bgm);
		room_goto(rMenu);
	};
	if(mouse_y<10){
		if(mouse_check_button(mb_left)){
			audio_sound_set_track_position(bgm,(mouse_x/room_width)*bgm_length);
		}
	}
	bgm_pos_now = audio_sound_get_track_position(bgm);
}
counter++;