/// @description Insert description here
// You can write your code in this editor
if(counter >= room_speed*60/oMainsys.bpm*(oMainsys.note_speed+oMainsys.judge_range)){
	instance_destroy(id);
	oPlayersys.hp-=10;
	counter = 0;
}
else if(counter >= room_speed*60/oMainsys.bpm*(oMainsys.note_speed-oMainsys.judge_range)){
	if(instance_place(x,y,oPlayerhit)){
		instance_destroy(id);
		oPlayersys.hp+=2;
		//oEnemysys.hp-=20;
		//counter = 0;
	}
	image_index++;
}
/*
else{
	if(instance_place(x,y,oPlayerhit)){
		instance_destroy(id);
		//oEnemysys.hp-=10;
		oPlayersys.hp-=5;
		//counter = 0;
	}
}
*/
counter++;