export interface Login {
    usuario: string;
    senha: string;
}

export interface Token {
    access_token: string;
    token_type: string;
    expires_in: number;
    user_id: string;
    user_name: string;
    user_mail: string;
    issued: string;
    expires: string;
}
