# ObserverStatePattern

jonah gibson 100910759
arshiya shahbazpour 100832558
Observer patter:

the observer pattern works by having th eplayer subscribe to the movement event in the playerINputHandler. the event is invoked by the handler whenever input is recieved. this method works well because it allows you to change how the player reacts to certain inputs depending on the situation in the game or even remove input by unsubscribing. 

state pattern:
the enemy has a state machine that tracks if they are alive and changes their motion based on that state.

we are happy with out implimentations because they worked well and within the timeframe. we finished everything. the longest part was spending more time than required on remembering rotations and bitwise. spend more time learning those before next time.

Object Pool:
List<gameobject> activePool;
List<gameObject> inactivePool;
update{
if(activepool.count < maxToSpawn){
if(inactivePool.count == 0) CreateNewTreeAndAddToPool
else{
remove tree from inactivePool
add tree to activePool
set the gameObject to active and its position to one of the spawnlocations
}
}
}
void returnToPool(gameobject returnedTree){
set gameobject inactive
remove it from the active pool
add it to the inactivepool
}

I created an object pool for the tree spawning. The pool works by having two lists, one for active trees and one for inactive trees. Whenever the number of active trees is less than the max that can be spawned, the update loop attempts to retrieve one from inactive pool and add it to the active pool, if there are not enough in the inactive pool it instantiates a new one and adds it. When a tree is moved off screen it adds itself back to the inactivePool for use again. This recycling reduces the amount of garbage created from repeated instantiating and destroying of identical game objects. Without using this method, there would be hundreds of trees being created and destroyed, each time creating a new allocation of memory which would cause noticable performance spikes when garbage collection happens. 

Dirty Flag:
treebehaviour:
update(){
if(playerSpeedChanged.isDirty){
set speed to players speed
}
move down equal to player speed
}

Rather than move the player, I move the trees down to create the illusion of movement. This means each tree needs to know what the players speed is, however when the player collides or has reached their maximum possible speed, they should need to update their speed. To fix this I made the players speed a dirty flag. If the players speed has changed, either due to being below their max speed or coliding with the enemy, the trees speed updates. The players speed is static as long as they are at their max speed. This means the trees only update their speed if the player is updating their speed, reducing uneeded calls and operations. 

I am pretty happy with my implimentation this week. If I had more time I would have liked to make a generic pool type that could be instantiated to pool specific objects, allowing me to pool anything in the game. I would ahve used this to pool enemy vehicles and the trees. 
I didnt really have any difficulties with this implimentation, these are topics Ive used quite extensively. 
If i were to do anything better enxt time, I would test more often during the process rather than just at the end. This caused me to panic just a little and was uneeded stress. 
I was able to impliment and docutment everything required in class with time to spare. 
Additionally I was able to add significantly more features in this period such as the speed system, UI, and collision effects (slow down on hit);
