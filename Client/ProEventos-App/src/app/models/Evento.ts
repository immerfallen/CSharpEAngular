import { Lote } from "./Lote"
import { PalestranteEvento } from "./PalestranteEvento"
import { RedeSocial } from "./RedeSocial"

export interface Evento {

 id: number
 local: string
 dataEvento?: Date
 tema: string
 qtdPessoas: number
 lote: Lote[]
 redesSociais: RedeSocial[]
 imagemUrl: string
 telefone: string
 email: string
 palestrantesEventos: PalestranteEvento[]
}
