var EventEmitter = require('events');

class Simulator extends EventEmitter{
    constructor() {
        this.lanes = [];
        this.sources = [];
        this.sinks = [];
    }
}

module.exports = Simulator;