var EventEmitter = require('events');




class Segment extends EventEmitter {
    /**
     * Road segment, the smallest road unit to hold one or more cars
     * @param {string} name name of this segment
     * @param {integer} capacity maximum car size units can this segment fit
     * @param {integer} inFlux maximum units of car sizes can get into this road segment
     * @param {integer} outFlux maximum units of car size can leave thsi segment
     */

    constructor(name, capacity, inFlux, outFlux) {
        super();
        this.occupancy = 0;
        this.name = name;
        this.capacity = capacity;
        this.inFlux = inFlux;
        this.outFlux = outFlux;
    }

    /**
     * attempt to fill segment, based on capacity ad flux, if not, reject 
     */
    fill(size) {
        var actualSize = Math.min(this.inFlux, size);
        if (this.occupancy + actualSize <= this.capacity) {
            this.emit('flow');
            this.occupancy += actualSize;
            return actualSize;
        } else {
            this.emit('full');
            return 0;
        }
    }

    /**
     * attempt to drain segment, based on capacity and flux, if not reject 
     */
    drain(size) {
        var actualSize = Math.min(this.inFlux, size, this.occupancy);
        this.occupancy -= actualSize;
        if (this.occupancy == 0) {
            this.emit('empty');
        }
        return actualSize;
    }

}
module.exports = Segment;