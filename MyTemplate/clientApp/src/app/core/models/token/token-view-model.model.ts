import { TokenInfo } from './token-info.model';
export interface TokenViewModel {
  status: number;
  message: string;
  tokenInfo: TokenInfo;
}
