/// @description Insert description here
// You can write your code in this editor
draw_set_colour(c_green);
draw_rectangle(140, 700, 240, 710, true);
draw_rectangle(140, 700, 140+(hp/maxhp)*100, 710, false);
draw_line(0,y,room_width,y);