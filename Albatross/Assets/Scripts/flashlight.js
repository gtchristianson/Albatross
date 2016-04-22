var flashlightOn : boolean = false;
  
 function Update () {
     //Checks if the boolean is true or false.
     if(flashlightOn == true){
         GetComponent.<Light>().intensity = 1;//If the boolean is true, then it sets the intensity to what ever you want.
     } else {
         if(flashlightOn == false){
             GetComponent.<Light>().intensity = 0;//If the boolean is false, then it sets the intensity to zero.
         }
     }
    
     //Checks if the F key is down and whether the boolean is on or off.
     if(Input.GetKeyDown(KeyCode.F) && flashlightOn == false){
         flashlightOn = true; //If the f key is down and the boolean is false, it sets the boolean to true.
     } else {
         if(Input.GetKeyDown(KeyCode.F) && flashlightOn == true) {
         flashlightOn = false;//If the f key is down and the boolean is true, it sets the boolean to false.
         }
     }
    
 }