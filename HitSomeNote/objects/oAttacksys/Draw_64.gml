/// @description Insert description here
// You can write your code in this editor
draw_set_color(c_lime);

if(note_pos<=oPlayersys.y){
	draw_rectangle(x-10,note_pos-3,x+10,note_pos+3,false);
}

note_pos+=note_movespeed;