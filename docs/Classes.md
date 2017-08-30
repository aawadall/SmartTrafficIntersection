# Classes
* Agent
* Direction.cs
* FourDirectionIntersection
* Lane
* Policy
* Program
* QPolicy
* Simulator
* Smart4WayIntersection
* TrafficController

## Agent
Is the brains of an intersection, a Reinforcement Learning AI agent, attempting to maximize a unitlity function; in our case, the negative average wait time in an intersection.

An agent relies on a policy to learn and act

## Direction.cs
A conceptual class, used to link traffic controllers to lanes.
Multiple lanes could have the same direction, hence a single traffic controller (e.g. traffic light) will control all lanes in the same direction.

Directions in this context are not strictly spatial directions, i.e. two physically parallel directions might have different traffic rules, and hence different traffic controllers. e.g. a stop sign, will require each car in each lane to wait for its turn 

## FourDirectionIntersection
## Lane
## Policy
## Program
## QPolicy
## Simulator
## Smart4WayIntersection
## TrafficController
