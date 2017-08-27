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

Current Model is designed that a single agent  controls an Intersection 

<a href="https://www.codecogs.com/eqnedit.php?latex=\mathcal{I}&space;=&space;\{\mathcal{D},\mathcal{L},\mathcal{C}\}" target="_blank"><img src="https://latex.codecogs.com/gif.latex?\mathcal{I}&space;=&space;\{\mathcal{D},\mathcal{L},\mathcal{C}\}," title="\mathcal{I} = \{\mathcal{D},\mathcal{L},\mathcal{C}\}," /></a>

made of one or more directoins 

<a href="https://www.codecogs.com/eqnedit.php?latex=d_i&space;\in&space;\mathcal{D}" target="_blank"><img src="https://latex.codecogs.com/gif.latex?d_i&space;\in&space;\mathcal{D}," title="d_i \in \mathcal{D}" /></a> 

Lanes 

<a href="https://www.codecogs.com/eqnedit.php?latex=l_j&space;\in&space;\mathcal{L}" target="_blank"><img src="https://latex.codecogs.com/gif.latex?l_j&space;\in&space;\mathcal{L}," title="l_j \in \mathcal{L}" /></a>

and Traffic Controllers 

<a href="https://www.codecogs.com/eqnedit.php?latex=c_k&space;\in&space;\mathcal{C}" target="_blank"><img src="https://latex.codecogs.com/gif.latex?c_k&space;\in&space;\mathcal{C}." title="c_k \in \mathcal{C}" /></a>

### Directions 

The direction is a conceptual entity used to identify where the traffic flows. It can be considered a vector in the traffic space listing all possible traffic flows.

It is used to:
* link lanes to traffic controllers
* detect potential collision 

### Lanes 
A lane is the physical lane, where traffic lines up. It contains a queue simulator with two parameters 

<a href="https://www.codecogs.com/eqnedit.php?latex=\phi_{in},&space;\text{incoming&space;traffic&space;flow}" target="_blank"><img src="https://latex.codecogs.com/gif.latex?\phi_{in},&space;\text{incoming&space;traffic&space;flow}" title="\phi_{in}, \text{incoming traffic flow}" /></a>

<a href="https://www.codecogs.com/eqnedit.php?latex=\phi_{in},&space;\text{incoming&space;traffic&space;flow}" target="_blank"><img src="https://latex.codecogs.com/gif.latex?\phi_{out},&space;\text{outgoing&space;traffic&space;flow}" title="\phi_{out}, \text{outgoing traffic flow}" /></a>

In addition, each lane has a direction as a property.

<a href="https://www.codecogs.com/eqnedit.php?latex=l_j&space;=&space;\{d_i,&space;\phi_{in},&space;\phi_{out}\}" target="_blank"><img src="https://latex.codecogs.com/gif.latex?l_j&space;=&space;\{d_i,&space;\phi_{in},&space;\phi_{out}\}" title="l_j = \{d_i, \phi_{in}, \phi_{out}\}" /></a>

When traffic is allowed,

<a href="https://www.codecogs.com/eqnedit.php?latex=c_k^{l_j^{d_i}}&space;=&space;true" target="_blank"><img src="https://latex.codecogs.com/gif.latex?c_k^{l_j^{d_i}}&space;=&space;true" title="c_k^{l_j^{d_i}} = true" /></a>

i.e. Traffic Controller associated with this lane allows traffic flowing out, it will dequeue using the 
<a href="https://www.codecogs.com/eqnedit.php?latex=\phi_{in},&space;\text{incoming&space;traffic&space;flow}" target="_blank"><img src="https://latex.codecogs.com/gif.latex?\phi_{out}" title="\phi_{out}, \text{outgoing traffic flow}" /></a>
rate parameter, and in both cases it will enqueue using the 
<a href="https://www.codecogs.com/eqnedit.php?latex=\phi_{in},&space;\text{incoming&space;traffic&space;flow}" target="_blank"><img src="https://latex.codecogs.com/gif.latex?\phi_{in}" title="\phi_{in}" /></a>
rate parameter.

And in all situations, the lane is capable of measuring total wait time for all clients queued in the lane 

<a href="https://www.codecogs.com/eqnedit.php?latex=t(l_j)&space;=&space;\sum_{\forall&space;v_i&space;\in&space;l_j}&space;t(v_i)," target="_blank"><img src="https://latex.codecogs.com/gif.latex?t(l_j)&space;=&space;\sum_{\forall&space;v_i&space;\in&space;l_j}&space;t(v_i)," title="t(l_j) = \sum_{\forall v_i \in l_j} t(v_i)," /></a>

where v are all vehicles or a pedistrians, currently linedup in this lane.

Such wait time is used as a cost function used by the agent to minimize.  

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

## [Issues](https://github.com/aawadall/SmartTrafficIntersection/issues)
* <strike>Currently, simulator is allowing traffic in the wrong direction </strike>
* <strike>Translating States from Simulation Space to AI Agent Space</strike>
* <strike>Translating Actions from AI Agent Space to Simulation Space</strike>
* General Performance Issue, running 1600 ticks takes more than 15 minuts.

## Current Developement
* <strike> Spawn FourDirectionIntersection into a Smart4WayIntersection  </strike> 
* <strike>Writing first agent to control Smart4WayIntersection</strike>
* Stabilizing AI Agent 
* Bug fixes 

## Future Developement
* Collision detection 
* Bad driver simulator
* Include Pedestrians to the simulated model 
* Unconstrained State/Action Space
* TD(&lambda;) policy 
