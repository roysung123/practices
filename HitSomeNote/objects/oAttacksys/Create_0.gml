/// @description Insert description here
// You can write your code in this editor
counter = 0;
depth = 1;
image_speed = 0;

note_type = 0;

note_pos = oEnemysys.y;

note_movespeed = (oPlayersys.y-oEnemysys.y)/(room_speed*60/oMainsys.bpm*oMainsys.note_speed);