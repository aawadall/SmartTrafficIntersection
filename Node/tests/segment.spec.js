var Segment = require('../simulator/segment');
var chai = require('chai');
chai.use(require('chai-events'));
var should = chai.should();

describe('Segment', function () {
    var segment = null;
    var capacity = 5;
    var inFlux = 2;
    var outFlux = 3;

    this.beforeEach('Segment Loader', function () {

        segment = new Segment('Mock Segment', capacity, inFlux, outFlux);
    });

    describe('Segment Attributes', function () {
        it('Should have a capacity', function () {
            segment.should.have.property('capacity');
            segment.capacity.should.equal(capacity);
        });
        it('Should have capacity populated', function () {
            segment.capacity.should.equal(capacity);
        });
        it('Should have in-flux', function () {
            segment.should.have.property('inFlux');
        });
        it('Should have in-flux populated', function () {
            segment.inFlux.should.equal(inFlux);
        });
        it('Should have out-flux', function () {
            segment.should.have.property('outFlux');
        });
        it('Should have out-flux populated', function () {
            segment.outFlux.should.equal(outFlux);
        });
    });

    describe('Flux', function () {
        describe('Methods', function () {
            it('Should accept more vehicles from adjacent segments', function () {
                segment.should.have.property('fill');
            });
            it('Should drain vehicles into adjacent segments', function () {
                segment.should.have.property('drain');
            });
        });


        describe('Limits', function () {
            it('Should have capacity increasing by car size', function () {
                var size = 1;
                segment.fill(size);
                segment.occupancy.should.equal(size);
            });
            it('Should have capacity decreses by car size', function () {
                var inSize = 2;
                var outSize = 1;
                segment.fill(inSize);
                segment.drain(outSize);
                segment.occupancy.should.equal(inSize - outSize);
            });
            it('Should not accept more cars if full capacity', function () {
                for (var index = 0; index < 1 + segment.capacity / inFlux; index++) {
                    segment.fill(inFlux);
                }
                segment.occupancy.should.not.be.above(segment.capacity);

            });
            it('Should not drain cars, if empty capacity', function () {
                segment.fill(inFlux);
                for (var index = 0; index < 1 + segment.capacity / outFlux; index++) {
                    segment.drain(outFlux);
                }
                segment.occupancy.should.not.be.below(0);
            });
        });

        describe('Events', function () {
            describe('Emitted events', function () {
                it('Should emit flow event when new cars enter', function () {
                    segment.fill(inFlux);
                    segment.should.emit('flow');
                });
                it('Should emit empty event when last car exit', function () {
                    segment.fill(inFlux);
                    for (var index = 0; index < 1 + segment.capacity / outFlux; index++) {
                        segment.drain(outFlux);
                    }
                    segment.should.emit('empty');
                });
                it('Should emit full event when capacity reached', function () {
                    for (var index = 0; index < 1 + segment.capacity / inFlux; index++) {
                        segment.fill(inFlux);
                    }
                    segment.should.emit('full');
                });

            });

            describe('Handled events', function () {

            });

            describe('Piped events', function () {

            });
        });
    });
});