const Source = require('../simulator/source');
const chai = require('chai');
chai.use(require('chai-events'));
chai.use(require('chai-uuid'));
const should = chai.should();

describe('Source', function () {
    var source = null;
    const name = 'Mock Source';
    const outFlux = 5;

    this.beforeEach('Source Loader', function () {
        source = new Source(name, outFlux);
    });
    describe('Properties', function () {
        it('Should have an id', function () {
            source.should.have.property('id');
        });
        it('Should have a name', function(){
            source.should.have.property('name');
        });
        it('Should have an outFlux', function () {
            source.should.have.property('outFlux');
        });
        it('Should have the id formatted as uuid/v1', function(){
            source.id.should.be.a.uuid('v1');
        });
        it(`Should have its name equal to ${name}`, function(){
            source.name.should.equal(name);
        });
        it(`Should have its outFlux equal to ${outFlux}`, function(){
            source.outFlux.should.equal(outFlux);
        });
    });
    describe('Behaviour', function () {
        it('Should generate a flux');
        it(`Flux should be less than or equal to ${outFlux}`);
    });
})
