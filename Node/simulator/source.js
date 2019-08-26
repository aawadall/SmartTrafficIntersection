const EventEmitter = require('events');
const uuidv1 = require('uuid/v1');

class Source extends EventEmitter {
    constructor(name, outFlux) {
        super();
        this.id = uuidv1(); 
        this.name = name;
        this.outFlux = outFlux;
    }

    tick = function () {       
        this.emit('flow', (flux) => {
            flux = Math.floor(Math.random() * outFlux);
        })
    }
}

module.exports = Source;