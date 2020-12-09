/// @description Insert description here
// You can write your code in this editor
//for(i=0;i<array_length(oEnemysys.note_now);i++){
//	draw_text(10+i*20,10,oEnemysys.note_now[i]);
//}
//draw_text(100,10,current_time);
//draw_text(130,30,audio_sound_get_track_position(bgm));
//draw_text(160,10,audio_sound_length(bgm));
draw_set_colour(c_green);
draw_rectangle(0, 0, room_width, 10, true);
draw_rectangle(0, 0, (bgm_pos_now/64)*(room_width), 10, false);