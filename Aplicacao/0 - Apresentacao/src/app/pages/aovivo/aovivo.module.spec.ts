import { AovivoModule } from './aovivo.module';

describe('AovivoModule', () => {
  let aovivoModule: AovivoModule;

  beforeEach(() => {
    aovivoModule = new AovivoModule();
  });

  it('should create an instance', () => {
    expect(aovivoModule).toBeTruthy();
  });
});
