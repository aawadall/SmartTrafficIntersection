const Source = require('../simulator/source');
const chai = require('chai');
chai.use(require('chai-events'));
const should = chai.should();

describe('Source', function () {
    var source = null;
    const name = 'Mock Source';
    const outFlux = 5;

    this.beforeEach('Source Loader', function () {
        source = new Source(name, outFlux);
    });
    describe('Properties', function () {
        it('Should have an id');
        it('Should have a name');
        it('Should have an outFlux');
        it('Should have the id formatted as uuid/v1');
        it(`Should have its name equal to ${name}`);
        it(`Should have its outFlux equal to ${outFlux}`);
    });
    describe('Behaviour', function () {
        it('Should generate a flux');
        it(`Flux should be less than or equal to ${outFlux}`);
    });
})
