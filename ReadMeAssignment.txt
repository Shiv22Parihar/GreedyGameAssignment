Please find below few instructions for using the .apk attached:

1. For Problem statement 2 (Creating Animations), tap on the animate button to start animations.
	a. First Top half plane Animation gets played.(Changing Scale)
	b. Then Bottom Right plane Animation gets played.(Rotation)
	c. And at last Bottom Left plane animation gets played.(Position)
2. For Problem statement 3, 2 buttons are provided as given in problem statement and a text field which displays the result.
3. For problem statement 4, I created a button with flip symbol, on clicking that button, planes get rearranged as expected in the 
	problem statement.

=====================------------------------------------====================================--------------------------------===============
	
Few Pointers for code understanding :-

1. PlaneGenerator is the main object that was asked in problem statement 1. 
2. It contains the method Renderer, which is called from PlaneManager script which is attached to the PlaneManager gameobject.	
3. Driver Functions are kept in PlaneManger gameobject.
4. Methods for Each problem statement are kept under separate regions in PlaneGenerator object.

=====================------------------------------------====================================--------------------------------===============

Few things i did on my own :-

1. Created buttons for problem statement 2 (For Animation) & 4 ( For Flipping Images), although they were not given in problem statement, 
	but i was not sure, how we are going to check those functionalities in the application that's why i created those buttons.
2. I'm taking Materials as input in the renderer function instead of Textures (I didn't got it working with texture, and because of time 
	limit I didn't researched enough on that.).
3. I Didn't tried different animations with other component apart from Transform.


=====================------------------------------------====================================--------------------------------===============

***NOTE: One problem I was unable to address is sometimes, one of the below plane or sometime the above half plane, doesn't 
		  shows up properly. I mean to say that, plane is rendered properly, but gets hidden behind the Large Containing plane	
		  But if we'll decrease the scale by using (Minus button), it appears Properly.