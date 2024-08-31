export class Informacao {
  constructor(
    public descricao: string
  ) {}
}

export class Dia {
  constructor(
    public id: string,
    public data: string, // Data no formato YYYY-MM-DD
    public informacao?: Informacao
  ) {}
}
