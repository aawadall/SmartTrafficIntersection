/**
 * Lane
 */
class Lane {
    
    constructor(name) {
        this.segments = [];
        this.name = name;
    } 

    simulate = function () {
        inflow = this.getFlow();
        segments.forEach(segment => {
            segment.feed
        });
    }
}

module.exports = Lane