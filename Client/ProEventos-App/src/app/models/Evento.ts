import { Lote } from "./Lote"
import { PalestranteEvento } from "./PalestranteEvento"
import { RedeSocial } from "./RedeSocial"

export interface Evento {

 Id: number

 Local: string

 DataEvento?: Date

 Tema: string

 QtdPessoas: number

 Lote: Lote[]

 RedesSociais: RedeSocial[]

 ImagemUrl: string

 Telefone: string

 Email: string

 PalestrantesEventos: PalestranteEvento[]

}
