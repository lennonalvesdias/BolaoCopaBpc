import { AuditoriaModule } from './auditoria.module';

describe('AuditoriaModule', () => {
  let auditoriaModule: AuditoriaModule;

  beforeEach(() => {
    auditoriaModule = new AuditoriaModule();
  });

  it('should create an instance', () => {
    expect(auditoriaModule).toBeTruthy();
  });
});
