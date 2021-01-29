
export class ContaPagar {
  id: number;
  nome: string;
  dataPagamento: Date;
  dataVencimento: Date;
  valorOriginal: number;
  emAtraso: boolean;
  valorCorrigido: number;
  quantidadeDiasAtraso: number;
  percentualMulta: number;
  percentualJurosDia: number;
  valorMulta: number;
  valorJurosDia: number;
 }
