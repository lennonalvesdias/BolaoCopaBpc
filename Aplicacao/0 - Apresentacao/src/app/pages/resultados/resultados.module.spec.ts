import { ResultadosModule } from './resultados.module';

describe('ResultadosModule', () => {
  let ResultadosModule: ResultadosModule;

  beforeEach(() => {
    ResultadosModule = new ResultadosModule();
  });

  it('should create an instance', () => {
    expect(ResultadosModule).toBeTruthy();
  });
});
