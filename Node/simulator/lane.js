var Segment = require('./segment');

function Lane(name){
    this.name = name;
    this.segments = [];
} 

Lane.prototype.addSegment = function(segment) {
    this.segments.append(segment);
};

module.exports = Lane;