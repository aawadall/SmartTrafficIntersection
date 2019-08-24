var EventEmitter = require('events');

class Simulator extends EventEmitter{
    constructor() {
        this.lanes = [];
        this.sources = [];
        this.sinks = [];
    }

    addLane = function(lane) {
        lanes.add(lane);
    }

    tick = function(){
        
    }
}

module.exports = Simulator;