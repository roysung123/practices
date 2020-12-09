/// @description Insert description here
// You can write your code in this editor
if(keyboard_check_pressed(oMainsys.key[keyset.key1])){
	with(instance_create_layer(room_width/5,oPlayersys.y,"Instances",oPlayerhit)){
		key_type = keyset.key1;
	}
}
if(keyboard_check_pressed(oMainsys.key[keyset.key2])){
	with(instance_create_layer(room_width/5*2,oPlayersys.y,"Instances",oPlayerhit)){
		key_type = keyset.key2;
	}
}
if(keyboard_check_pressed(oMainsys.key[keyset.key3])){
	with(instance_create_layer(room_width/5*3,oPlayersys.y,"Instances",oPlayerhit)){
		key_type = keyset.key3;
	}
}
if(keyboard_check_pressed(oMainsys.key[keyset.key4])){
	with(instance_create_layer(room_width/5*4,oPlayersys.y,"Instances",oPlayerhit)){
		key_type = keyset.key4;
	}
}
hp = min(hp,maxhp);