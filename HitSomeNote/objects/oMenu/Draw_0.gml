/// @description Insert description here
// You can write your code in this editor
for(i=0;i<buttons;i++){
	draw_set_halign(fa_center);
	draw_set_color(c_silver);
	if(i == last_sel){
		draw_roundrect(menu_x-button_w_half,menu_y+button_h_half*(2*i-0.5),menu_x+button_w_half,menu_y+button_h_half*(2*i+1.5),true);
	}
	draw_text(menu_x,menu_y+button_h_half*2*i,button[i]);
}
if(global.win_flag == noone){
	//do nothing
}
else if(global.win_flag){
	draw_text(room_width/2,room_height/5*4,"Clear!");
}
else if(!global.win_flag){
	draw_text(room_width/2,room_height/5*4,"Failed");
}