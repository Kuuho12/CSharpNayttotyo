# Shakki

Tämä on peli on klassinen shakki ilman erikoissiirtoja tornitus ja en passant, eikä sotilaita voi muuttaa toisiksi 
nappuloiksi viemellä ne laudan päähän. Peli alkaa, kun painaa Aloite peli-napista. Nappuloita liikutetaan painamalla
nappulaa ja sitten pinamalla jotain mahdollista ruutua liikkua, jotka ovat joko pisteellä merkittyjä tyhjiä ruutuja
tai punataustaisia vastustajan nappuloita. Aina kun jomman kumman kuningas on shakissa, kuninkaalle tulee punainen
tausta. Peli päättyy shakkimattiin, jolloin Aloita peli-nappulan ylle ilmestyy sana "Checkmate".

## Koodin esittely

Jokaisella nappulalla on hyvin samankaltaiset click-eventhandlerit:

![screenshot](images/white_pawn.png)

Eka if estää nappulaa liikkumasta ennen kuin peli alkaa, toinen vastaa liikkumisprosessin aloittamisesta omalla
vuorolla ja kolmas kun vihollisen nappula syö oman nappula.

![screenshot](images/clicking_piece.png)

ClickingPiece on pitkä funktio, joka näyttää mihin klikattava nappula voi liikkua luomalla pisteitä kartalle ja 
muuttamalla napattavien vastustajan nappuloiden taustavärin punaiseksi. DeleteMoveSignals pyyhkii aiemmat tällaiset 
merkinnät.

![screenshot](images/rook_closeup.png)

Piece argumentti kertoo nappulan tyypin ja cellPosition nappulan sijainnin laudalla. Tässä on tornin liikkuminen.
Ihan aluksi for-loopissa varmistetaan, ettei testattava ruutu ole laudan ulkopuolella. Sen jälkeen katsotaan
occupiedTiles-listasta, onko ruudulla joku noppula. Jos ei ole, pitää vielä varmistaa IsGonnaCheck-funktiolla,
ettei siirto veisi omaa kuningasta shakkiin. Jos ei, niin laudalle ilmestyy piste, jota klikkaamalla nappula
liikkuu ruutuun. Jos ruudulla onkin toinen nappula tiellä, niin katsotaan onko vastustajan vai oma nappula. Jos on
vastustajan, niin vielä varmistetaan ettei liike shakita omaa kuningasta, ennenkuin merkitään nappula napattavaksi.

![sreenshot](images/rook_all.png)

Eri nappuloiden liikkeiden hoitaminen vie paljon tilaa, tässä koko tornin liike
