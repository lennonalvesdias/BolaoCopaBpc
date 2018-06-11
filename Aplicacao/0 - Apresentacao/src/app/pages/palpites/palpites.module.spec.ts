import { PalpitesModule } from './palpites.module';

describe('PalpitesModule', () => {
  let palpitesModule: PalpitesModule;

  beforeEach(() => {
    palpitesModule = new PalpitesModule();
  });

  it('should create an instance', () => {
    expect(palpitesModule).toBeTruthy();
  });
});
