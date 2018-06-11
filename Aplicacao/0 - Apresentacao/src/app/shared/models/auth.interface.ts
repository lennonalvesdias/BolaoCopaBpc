export interface Login {
    email: string;
    senha: string;
}

export interface Token {
    authenticated: Boolean;
    created: string;
    expiration: string;
    accessToken: string;
    message: string;
}

export interface NovaSenha {
    email: string;
    novaSenha: string;
    novaSenhaConfirmacao: string;
}