/// @description Insert description here
// You can write your code in this editor
//end_flag = true;
for(i=0;i<array_length(note_now);i++){
	if(note_now[i] < array_length(note_sheet[i])){
		//end_flag = false;
		if(counter>=room_speed*60/oMainsys.bpm*(note_sheet[i][note_now[i]])){
			with(instance_create_layer(room_width/5*(i+1),oPlayersys.y,"Instances",oAttacksys)){
				note_type = 1;
			}
			note_now[i]++;
		}
	}
}
counter++;