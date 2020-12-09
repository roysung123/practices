/// @description Insert description here
// You can write your code in this editor
menu_move = keyboard_check_pressed(vk_down)-keyboard_check_pressed(vk_up);

menu_index += menu_move;
if(menu_index<0){menu_index = buttons-1;}
menu_index = menu_index%buttons;

last_sel = menu_index;
if(keyboard_check(vk_enter)){
	switch(last_sel){
		case 0:
			room_goto(rPlay);
			break;
		case 1:
			game_end();
			break;
	}
}