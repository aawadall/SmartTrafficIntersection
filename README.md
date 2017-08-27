# SmartTrafficIntersection
Another toy project of a traffic intersection controlled by a RL agent to optimize traffic flow

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

## Bugs
* <strike>Currently, simulator is allowing traffic in the wrong direction </strike>

## Current Developement
* Spawn FourDirectionIntersection into a Smart4WayIntersection   
* Writing first agent to control Smart4WayIntersection

## Future Developement
* Collision detection 
* Bad driver simulator
* Pedestrians 