﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineTruboCabla.Gameplay
{
    public enum MoveResult
    {
        Valid,
        Invalid,
        Check,
        Checkmate,
        Stalemate
    }
}
