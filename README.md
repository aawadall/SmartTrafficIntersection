# SmartTrafficIntersection

[![Travis Badge](https://travis-ci.com/aawadall/SmartTrafficIntersection.svg?branch=master)](https://travis-ci.com/aawadall/SmartTrafficIntersection.svg?branch=master)
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/69d126b53d6144aaa5b622e926f0cf2a)](https://www.codacy.com/app/aawadall/SmartTrafficIntersection?utm_source=github.com&utm_medium=referral&utm_content=aawadall/SmartTrafficIntersection&utm_campaign=badger)
[![BCH compliance](https://bettercodehub.com/edge/badge/aawadall/SmartTrafficIntersection?branch=master)](https://bettercodehub.com/)
[![CodeFactor](https://www.codefactor.io/repository/github/aawadall/smarttrafficintersection/badge)](https://www.codefactor.io/repository/github/aawadall/smarttrafficintersection)

Another AI toy project; Of a traffic intersection controlled by an AI agent to optimize traffic flow and avoid collission. 

![Sample 8 lanes intersection](https://github.com/aawadall/SmartTrafficIntersection/blob/master/GRrTr.png)

_I would love to hear your feedback, especially bugs found in the code and suggested features._ 

_Alpha release is scheduled at the end of September 2017, while the Beta is scheduled at End of October. I would love to stuff in as much as possible before moving on to the next project._ 

_Also, if someone can help me out in the visualization part, that would be awsome!_

_Thanks_ 

## How to use it
### on Linux
_upcoming, I will port this code from mono to .NET Core 2.1_

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

<a href="https://www.codecogs.com/eqnedit.php?latex=c_k^p&space;.&space;d_i&space;=&space;true" target="_blank"><img src="https://latex.codecogs.com/gif.latex?c_k^p&space;.&space;d_i&space;=&space;true" title="c_k^p . d_i = true" /></a>

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
Traffic Controllers are general case of a traffic light in an intersection. A traffic controller can be thought of as a pair boolean vectors; each vector has an element for direction, such that 

<a href="https://www.codecogs.com/eqnedit.php?latex=\mathbf{c_k}&space;=&space;\left(c_k^p&space;,&space;c_k^p&space;\right)" target="_blank"><img src="https://latex.codecogs.com/gif.latex?\mathbf{c_k}&space;=&space;\left(c_k^p&space;&space;c_k^s&space;\right)" title="\mathbf{c_k} = \left(c_k^p  c_k^s \right)" /></a>

First vector <a href="https://www.codecogs.com/eqnedit.php?latex=c_k^p" target="_blank"><img src="https://latex.codecogs.com/gif.latex?c_k^p" title="c_k^p" /></a>, is the set of directions allowed to have non risky traffic flowwing, e.g. northbound and southbound traffic are allowed to flow freely. While the second vector <a href="https://www.codecogs.com/eqnedit.php?latex=c_k^s" target="_blank"><img src="https://latex.codecogs.com/gif.latex?c_k^s" title="c_k^s" /></a> is the secondary traffic allowed as per this controller. It means that the traffic of this direction can flow after yielding for incoming traffic from other primary directions, if collision is detected. e.g. left turn wen no dedicated controller for left is green, or right turn, when pedistrians are allowed to cross.

Current model is considering a simple binary traffic light only, with two states; true for green and false for red; 

<a href="https://www.codecogs.com/eqnedit.php?latex=c_k^p^{(i)}&space;\in&space;\left&space;\{&space;true,&space;false&space;\right&space;\},c_k^s^{(i)}&space;\in&space;\left&space;\{&space;true,&space;false&space;\right&space;\}&space;\forall&space;i" target="_blank"><img src="https://latex.codecogs.com/gif.latex?c_k^p^{(i)}&space;\in&space;\left&space;\{&space;true,&space;false&space;\right&space;\},c_k^s^{(i)}&space;\in&space;\left&space;\{&space;true,&space;false&space;\right&space;\}&space;\forall&space;i" title="c_k^p^{(i)} \in \left \{ true, false \right \},c_k^s^{(i)} \in \left \{ true, false \right \} \forall i" /></a>

## Components
This project is planned to have the following components:

### Simulation Component
Lanes, Traffic Controllers, and Intersections, This should simulate traffic in a given intersection configuration, with the optoin to manually control the controller behaviour if dynamic (i.e. not a stop sign or a roundabout)
<Complete>

### AI Component
This is a Reinforcement Learning AI agent controlling traffic controller to optimize metrics 
<Complete>

### Visualiztion Component  
Visualize intersection in terms of lanes, controller status and traffic accumilation 
<Pending>

## [Issues](https://github.com/aawadall/SmartTrafficIntersection/issues)
* <strike>Currently, simulator is allowing traffic in the wrong direction </strike>
* <strike>Translating States from Simulation Space to AI Agent Space</strike>
* <strike>Translating Actions from AI Agent Space to Simulation Space</strike>
* General Performance Issue, running 1600 ticks takes more than 15 minuts.

## Current Developement
### Alpha Release 
Expected End of September 2017
* <strike> Spawn FourDirectionIntersection into a Smart4WayIntersection  </strike> 
* <strike>Writing first agent to control Smart4WayIntersection</strike>
* <strike>Stabilizing AI Agent </strike>
* <strike>Bug fixes </strike>
* Visualization on a desktop application 
* Fixing known issues 

## Future Releases 
### Beta  
Expected End of October 2017
* User control traffic simulation 
* User control AI parameters 
* Learning Analytics 
* General direction/lane association, using vectors of booleans 
* Performance improvement 
* Fixing known issues 

### Stable Release 1.0
Expected End of November 2017
* Web version of the application 
* TD(&lambda;) agent 
* Read configuration of intersection from a file/database 
* Fixing known issues 

## Future Work
### Collision detection 
for a direction to detect if incoming traffic is floowing, and hence detect potential collision and simulate a collision in the future for an unconstrained ystem

### Bad driver simulator
Simulate a driver driving slowly, too fast, or running a red light 

### Include Pedestrians to the simulated model 
an extra lane, with a dedicated direction 

### Unconstrained State/Action Space
Alow the controller to pick wahtever actions, even if the result might end up in a simulated collision. this will allow the system to come up with creative solutions


### TD(lambda)
TD(&lambda;) policy 

### Web Application
port the solution to a web application and allow users to play with it

## Message to Students
We appreciate your visit to this repo, and feel proud that you landed here.
We have a request.. PLEASE dn NOT copy code from this repo and paste it into your coursework assignment. 

