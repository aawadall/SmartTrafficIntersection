# SmartTrafficIntersection
Another AI toy project; Of a traffic intersection controlled by an AI agent to optimize traffic flow and avoid collission. 

![Sample 8 lanes intersection](https://github.com/aawadall/SmartTrafficIntersection/blob/master/GRrTr.png)
## How to use it
### on Linux
#### Install Mono .NET framework on your machine
Check [here](http://www.mono-project.com/download/#download-lin) 

#### Download/Clone the project at your Machine 
Create a directory where you want to have your code 

`mkdir Traffic`

go to that location 

`cd Traffic`

Clone repo onyour machine 

`git clone https://github.com/aawadall/SmartTrafficIntersection.git`

#### Compile and Run
Go to Code Location

`cd SmartTrafficIntersection`

Compile

`mcs -out:Simulator.exe *.cs`

Run

`mono Simulator.exe`

## Theoritical Model 

Current Model is designed that a single agent  controls an Intersection <a href="https://www.codecogs.com/eqnedit.php?latex=\mathcal{I}&space;=&space;\{\mathcal{D},\mathcal{L},\mathcal{C}\}" target="_blank"><img src="https://latex.codecogs.com/gif.latex?\mathcal{I}&space;=&space;\{\mathcal{D},\mathcal{L},\mathcal{C}\}" title="\mathcal{I} = \{\mathcal{D},\mathcal{L},\mathcal{C}\}" /></a>; made of one or more directoins <a href="https://www.codecogs.com/eqnedit.php?latex=d_i&space;\in&space;\mathcal{D}" target="_blank"><img src="https://latex.codecogs.com/gif.latex?d_i&space;\in&space;\mathcal{D}" title="d_i \in \mathcal{D}" /></a>, Lanes <a href="https://www.codecogs.com/eqnedit.php?latex=l_j&space;\in&space;\mathcal{L}" target="_blank"><img src="https://latex.codecogs.com/gif.latex?l_j&space;\in&space;\mathcal{L}" title="l_j \in \mathcal{L}" /></a>, and Traffic Controllers <a href="https://www.codecogs.com/eqnedit.php?latex=c_k&space;\in&space;\mathcal{C}" target="_blank"><img src="https://latex.codecogs.com/gif.latex?c_k&space;\in&space;\mathcal{C}" title="c_k \in \mathcal{C}" /></a>

### Directions 

The direction is a conceptual entity used to identify where the traffic flows. It can be considered a vector in the traffic space listing all possible traffic flows.

It is used to:
* link lanes to traffic controllers
* detect potential collision 

### Lanes 
A lane is the physical lane, where traffic lines up. It contains a queue simulator with _flow<sub>in</sub>_ and _flow<sub>out</sub>_ parameters. 

Each lane has a direction as a property.

When traffic is allowed, i.e. Traffic Controller _c<sub>k</sub>_ associated with this lane allows traffic flowing out, it will dequeue using the _flow<sub>out</sub>_ rate, and in both cases it will enqueue using the _flow<sub>in</sub>_ rate.

And in all situations, the lane is capable of measuring total wait time for all clients queued in the lane t(_l<sub>j</sub>_) = &Sigma; t(_client_) &forall; _client_ &in; _l<sub>j</sub>_. Such wait time is used as a cost function to minimize.  

### Traffic Controllers 
Traffic Controllers are general case of a traffic light in an intersection. 

Current model is considering a simple binary traffic light only, with two states {_False_ &rarr; _Red_,_True_ &rarr; _Green_}.

In addition to states, a traffic controller has a primary direction (_d<sup>(p)</sup>_) associated with it, and a set of secondary directions (_d<sup>(s)</sup><sub>i</sub>_ &in; _D<sup>(s)</sup>_ ), such that _d<sup>(p)</sup>_ is guaranteed to move safely without bothering about incoming traffic, while all _d<sup>(s)</sup><sub>i</sub>_ &in; _D<sup>(s)</sup>_ are allowed to move but they should yied to incoming traffic from the direction _d<sup>(p)</sup>_. e.g. left turn when there is incoming traffic from opposite direction, or right turn when there are pedistrians crossing.

Secondary direction can be handled by checking if all incoming lanes from opposite direction are empty. _this feature is not handled yet_

## Components
### Simulation Component
Lanes, Traffic Controllers, and Intersections, This should simulate traffic in a given intersection configuration, with the optoin to manually control the controller behaviour if dynamic (i.e. not a stop sign or a roundabout)

### AI Component
This is a Reinforcement Learning AI agent controlling traffic controller to optimize metrics 

### Visualiztion Component  
Visualize intersection in terms of lanes, controller status and traffic accumilation 

## Finished Objects
* Traffic Simulator
* Traffic Controller {Stop Sign, raffic Light, etc.} General class now
* Traffic Direction; a conceptual object used to describe traffic flow in an intersection and to link lanes to traffic controllers 
* Lane, where cars line up. Controlled by the Traffic Controller, Each lane has its own parameterized traffic simulator  
* General Purpose Intersection object 
* Four Way intersection (with only primary traffic available, and no left turns)

## Issues
* <strike>Currently, simulator is allowing traffic in the wrong direction </strike>
* Translating States from Simulation Space to AI Agent Space
* Translating Actions from AI Agent Space to Simulation Space

## Current Developement
* <strike> Spawn FourDirectionIntersection into a Smart4WayIntersection  </strike> 
* <strike>Writing first agent to control Smart4WayIntersection</strike>
* Stabilizing AI Agent 

## Future Developement
* Collision detection 
* Bad driver simulator
* Include Pedestrians to the simulated model 
* Unconstrained State/Action Space

