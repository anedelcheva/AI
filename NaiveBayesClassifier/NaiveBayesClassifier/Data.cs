﻿namespace NaiveBayesClassifier
{
    class Data
    {
        // DATA
        public static char[,] DATA = new char[,]
        {
            {'n','y','n','y','y','y','n','n','n','y','?','y','y','y','n','y','r'},
            {'n','y','n','y','y','y','n','n','n','n','n','y','y','y','n','?','r'},
            {'?','y','y','?','y','y','n','n','n','n','y','n','y','y','n','n','d'},
            {'n','y','y','n','?','y','n','n','n','n','y','n','y','n','n','y','d'},
            {'y','y','y','n','y','y','n','n','n','n','y','?','y','y','y','y','d'},
            {'n','y','y','n','y','y','n','n','n','n','n','n','y','y','y','y','d'},
            {'n','y','n','y','y','y','n','n','n','n','n','n','?','y','y','y','d'},
            {'n','y','n','y','y','y','n','n','n','n','n','n','y','y','?','y','r'},
            {'n','y','n','y','y','y','n','n','n','n','n','y','y','y','n','y','r'},
            {'y','y','y','n','n','n','y','y','y','n','n','n','n','n','?','?','d'},
            {'n','y','n','y','y','n','n','n','n','n','?','?','y','y','n','n','r'},
            {'n','y','n','y','y','y','n','n','n','n','y','?','y','y','?','?','r'},
            {'n','y','y','n','n','n','y','y','y','n','n','n','y','n','?','?','d'},
            {'y','y','y','n','n','y','y','y','?','y','y','?','n','n','y','?','d'},
            {'n','y','n','y','y','y','n','n','n','n','n','y','?','?','n','?','r'},
            {'n','y','n','y','y','y','n','n','n','y','n','y','y','?','n','?','r'},
            {'y','n','y','n','n','y','n','y','?','y','y','y','?','n','n','y','d'},
            {'y','?','y','n','n','n','y','y','y','n','n','n','y','n','y','y','d'},
            {'n','y','n','y','y','y','n','n','n','n','n','?','y','y','n','n','r'},
            {'y','y','y','n','n','n','y','y','y','n','y','n','n','n','y','y','d'},
            {'y','y','y','n','n','?','y','y','n','n','y','n','n','n','y','y','d'},
            {'y','y','y','n','n','n','y','y','y','n','n','n','?','?','y','y','d'},
            {'y','?','y','n','n','n','y','y','y','n','n','?','n','n','y','y','d'},
            {'y','y','y','n','n','n','y','y','y','n','n','n','n','n','y','y','d'},
            {'y','n','y','n','n','n','y','y','y','n','n','n','n','n','y','?','d'},
            {'y','n','y','n','n','n','y','y','y','y','n','n','n','n','y','y','d'},
            {'y','n','y','n','n','n','y','y','y','n','y','n','n','n','y','y','d'},
            {'y','y','y','n','n','n','y','y','y','n','y','n','n','n','y','y','d'},
            {'y','n','n','y','y','n','y','y','y','n','n','y','y','y','n','y','r'},
            {'y','y','y','n','n','n','y','y','y','n','y','n','n','n','y','y','d'},
            {'n','y','n','y','y','y','n','n','n','n','n','y','y','y','n','n','r'},
            {'y','y','y','n','n','n','y','y','y','n','y','n','n','n','y','?','d'},
            {'y','y','y','n','n','n','y','y','y','y','n','n','y','n','y','y','d'},
            {'n','y','n','y','y','y','n','n','n','n','n','y','y','y','n','y','r'},
            {'y','y','y','n','n','n','y','y','y','n','n','n','n','n','y','y','d'},
            {'n','y','n','y','y','y','n','n','n','n','n','y','y','y','n','n','r'},
            {'y','?','n','y','y','y','n','n','n','y','n','y','?','y','n','y','r'},
            {'y','y','n','y','y','y','n','n','n','n','n','n','y','y','n','y','r'},
            {'n','y','n','y','y','y','n','n','n','y','n','y','y','y','n','n','r'},
            {'y','n','y','n','n','n','y','y','y','y','y','n','y','n','y','y','d'},
            {'y','y','y','n','n','n','y','y','y','n','?','n','n','n','n','?','d'},
            {'y','y','y','n','n','n','y','y','y','n','n','n','n','n','y','?','d'},
            {'y','n','y','n','n','n','y','y','y','n','n','n','n','n','n','y','d'},
            {'y','n','y','n','n','n','y','y','y','n','n','n','n','n','y','y','d'},
            {'y','y','y','n','n','n','y','y','y','n','y','n','n','n','n','?','d'},
            {'y','y','y','n','n','n','y','y','?','n','y','n','n','n','y','?','d'},
            {'y','y','y','n','n','n','y','y','y','n','n','n','n','n','n','y','d'},
            {'y','n','y','n','n','n','y','y','?','n','n','n','n','n','n','?','d'},
            {'y','y','y','n','n','n','y','y','n','n','n','n','n','y','n','y','d'},
            {'n','?','n','y','y','y','n','n','n','n','n','y','y','y','n','n','r'},
            {'y','y','y','n','n','n','y','y','y','n','y','n','n','n','y','y','d'},
            {'n','y','n','y','y','y','n','?','n','n','n','y','y','y','n','y','r'},
            {'y','y','y','n','n','n','y','y','y','n','n','n','n','n','?','?','d'},
            {'y','y','n','y','y','y','n','n','n','y','n','y','y','y','n','n','r'},
            {'y','y','y','n','n','y','?','y','n','n','y','y','n','y','n','?','d'},
            {'n','y','n','y','y','y','n','n','n','y','y','y','y','y','n','n','r'},
            {'n','y','n','y','y','y','n','n','n','y','y','y','y','y','n','y','r'},
            {'n','y','n','y','y','y','n','n','n','y','n','y','y','y','n','y','r'},
            {'n','y','n','y','y','y','n','n','n','y','n','y','y','y','n','y','r'},
            {'n','y','n','y','y','y','n','n','n','y','n','y','y','y','n','?','r'},
            {'y','y','y','n','n','?','y','y','y','y','n','n','n','n','y','?','d'},
            {'n','y','n','y','y','y','n','n','n','n','n','y','y','y','n','n','r'},
            {'y','y','y','n','n','n','y','y','y','n','n','n','n','n','n','?','d'},
            {'y','y','y','n','n','n','y','y','y','n','y','n','n','n','n','y','d'},
            {'y','y','y','n','n','n','y','y','y','n','y','?','n','n','n','y','d'},
            {'y','y','n','y','y','y','y','n','n','n','n','y','y','y','n','y','r'},
            {'n','y','n','y','y','y','y','n','n','n','y','y','y','y','n','y','r'},
            {'n','y','n','y','y','y','n','n','n','y','n','y','y','y','n','n','r'},
            {'y','?','y','n','n','n','y','y','y','n','n','n','y','n','y','y','d'},
            {'y','y','y','n','n','n','y','y','y','n','n','n','n','n','y','y','d'},
            {'y','n','y','n','n','n','y','y','y','n','n','n','y','n','y','?','d'},
            {'y','y','y','y','n','n','y','y','y','y','y','n','n','y','n','y','r'},
            {'y','y','y','n','n','n','y','y','y','n','y','n','n','n','y','?','d'},
            {'y','n','y','y','y','n','y','n','y','y','n','n','y','y','n','y','r'},
            {'y','n','y','n','n','y','y','y','y','y','y','n','n','y','y','y','d'},
            {'n','y','y','y','y','y','n','n','n','y','y','n','y','y','n','n','d'},
            {'n','y','y','n','y','y','n','n','n','y','y','y','y','y','n','?','d'},
            {'n','y','y','y','y','y','n','y','y','y','y','y','y','y','n','y','d'},
            {'y','y','y','n','y','y','n','n','n','y','y','n','y','y','n','y','d'},
            {'n','n','n','y','y','n','n','n','n','y','n','y','y','y','n','n','r'},
            {'y','n','y','n','n','y','y','y','y','y','n','y','n','y','n','?','d'},
            {'y','n','y','n','n','n','y','y','?','y','y','y','n','y','n','y','d'},
            {'n','n','n','y','y','y','n','n','n','y','n','y','y','y','n','y','r'},
            {'n','n','n','y','y','y','n','n','n','n','n','y','y','y','n','n','r'},
            {'n','?','n','y','y','y','n','n','n','y','n','y','y','y','n','n','r'},
            {'n','n','y','n','y','y','n','n','n','y','y','y','y','y','n','y','d'},
            {'n','n','n','y','y','y','n','n','n','y','n','y','y','y','n','n','r'},
            {'n','n','n','y','y','y','n','n','n','n','n','y','y','y','n','n','r'},
            {'n','y','y','n','y','y','y','n','y','y','y','n','y','y','n','y','d'},
            {'n','n','n','y','y','y','n','n','n','y','n','?','y','y','n','?','r'},
            {'y','n','y','n','n','n','y','y','y','y','n','n','n','n','y','y','d'},
            {'y','n','y','n','n','n','y','y','y','y','y','n','n','n','y','y','d'},
            {'y','y','y','n','n','n','y','y','n','y','y','n','n','?','y','y','d'},
            {'y','n','y','n','n','n','y','n','y','y','y','n','n','n','y','y','d'},
            {'y','n','y','n','y','y','n','n','n','n','n','n','n','n','n','y','d'},
            {'y','n','y','n','y','y','n','?','?','n','y','?','?','?','y','y','d'},
            {'n','n','?','n','y','y','n','n','n','n','y','y','y','y','n','y','d'},
            {'y','n','n','n','y','y','y','n','n','y','y','n','n','y','n','y','d'},
            {'y','y','y','n','n','y','y','y','y','y','n','n','n','n','n','y','d'},
            {'n','n','n','y','y','y','n','n','n','y','?','y','y','y','n','n','r'},
            {'y','n','n','n','y','y','n','n','n','n','y','y','n','y','n','y','d'},
            {'y','n','y','n','y','y','y','n','n','n','y','n','n','y','n','y','d'},
            {'y','n','y','n','y','y','y','n','?','n','y','n','y','y','y','?','d'},
            {'y','n','n','n','y','y','?','n','?','n','n','n','n','y','?','n','d'},
            {'?','?','?','?','n','y','y','y','y','y','?','n','y','y','n','?','d'},
            {'y','y','y','n','n','n','n','y','y','n','y','n','n','n','y','y','d'},
            {'n','y','n','y','y','y','n','n','n','n','n','y','y','y','n','y','r'},
            {'n','?','?','?','?','?','?','?','?','?','?','?','?','y','?','?','r'},
            {'y','?','y','n','n','n','y','y','y','n','n','n','n','n','y','?','d'},
            {'y','?','y','n','n','n','y','y','y','n','n','n','n','n','y','?','d'},
            {'n','n','y','n','n','n','y','y','y','y','n','n','n','n','y','y','d'},
            {'n','?','n','y','y','y','n','n','n','y','n','y','y','y','n','y','r'},
            {'n','?','y','n','n','y','y','y','n','y','n','n','n','n','y','?','d'},
            {'n','?','n','y','y','y','n','n','n','y','n','y','y','y','n','n','r'},
            {'y','?','y','n','n','n','y','y','y','n','n','n','n','n','y','?','d'},
            {'n','?','y','n','?','?','y','y','y','y','?','?','n','n','y','y','d'},
            {'y','n','y','n','n','n','y','y','y','n','y','n','n','n','y','y','d'},
            {'y','y','y','y','y','n','y','n','n','n','n','y','y','y','n','y','r'},
            {'n','y','y','n','n','n','n','y','y','y','y','n','n','n','y','y','d'},
            {'n','n','n','y','y','y','n','n','n','n','n','y','y','y','n','n','r'},
            {'n','?','?','y','y','y','n','n','n','y','n','y','y','y','?','y','r'},
            {'n','?','n','y','y','y','n','n','n','y','n','y','y','y','n','y','r'},
            {'n','n','n','y','y','y','n','n','n','y','n','y','n','y','n','y','r'},
            {'y','?','n','y','y','y','n','y','n','n','n','y','y','y','n','y','r'},
            {'n','?','y','n','n','n','y','y','y','n','n','n','n','n','y','y','d'},
            {'n','?','n','y','y','y','n','n','n','y','n','y','y','y','n','y','r'},
            {'n','?','n','y','y','y','n','n','n','n','n','y','y','y','n','n','r'},
            {'n','?','y','n','n','n','y','y','y','y','y','n','n','y','y','y','d'},
            {'n','?','y','n','n','y','n','y','n','y','y','n','n','n','y','y','d'},
            {'?','?','y','n','n','n','y','y','?','n','?','?','?','?','?','?','d'},
            {'y','?','y','n','?','?','y','y','y','n','n','n','n','n','y','?','d'},
            {'n','n','y','n','n','y','n','y','y','y','n','n','n','y','n','y','d'},
            {'n','n','n','y','y','y','n','n','n','y','n','y','y','y','n','?','r'},
            {'n','n','n','y','y','y','n','n','n','y','n','y','y','y','n','y','r'},
            {'n','n','n','y','y','y','n','n','n','n','n','y','y','y','n','?','r'},
            {'n','n','n','y','y','y','n','n','n','y','n','y','y','y','n','n','r'},
            {'n','y','n','y','y','y','n','n','n','y','y','y','y','n','n','y','r'},
            {'n','?','y','n','n','y','y','y','y','y','n','n','n','y','y','y','d'},
            {'n','n','y','n','n','y','y','y','y','y','n','n','n','y','n','y','d'},
            {'y','n','y','n','n','y','y','y','y','n','n','n','n','n','y','y','d'},
            {'n','n','n','y','n','n','y','y','y','y','n','n','y','y','n','y','r'},
            {'n','n','n','y','y','y','y','y','y','y','n','y','y','y','?','y','r'},
            {'n','n','n','y','y','y','y','y','y','y','n','y','y','y','n','y','r'},
            {'?','y','n','n','n','n','y','y','y','y','y','n','n','y','y','y','d'},
            {'n','?','n','n','n','y','y','y','y','y','n','n','n','y','n','?','d'},
            {'n','n','y','n','n','y','y','y','y','y','n','n','n','y','?','y','d'},
            {'n','y','n','y','y','y','n','n','n','n','n','y','y','y','n','y','r'},
            {'n','n','n','n','n','n','y','y','y','y','n','y','y','y','y','y','d'},
            {'n','y','n','y','y','y','n','n','n','y','y','y','y','y','n','y','r'},
            {'n','n','y','n','n','n','y','y','y','y','n','n','y','n','y','y','d'},
            {'y','y','n','y','y','y','n','n','n','y','n','y','y','y','n','y','r'},
            {'y','y','?','y','y','y','n','n','y','n','y','?','y','y','n','n','d'},
            {'n','y','y','n','n','y','n','y','y','y','y','n','y','n','y','y','d'},
            {'n','n','y','n','n','y','y','y','y','y','y','n','y','y','n','y','d'},
            {'n','y','n','y','y','y','n','n','n','n','n','y','y','y','n','n','r'},
            {'y','y','n','y','y','y','n','?','n','n','y','y','y','y','n','n','r'},
            {'y','y','n','y','y','y','y','n','n','n','n','y','y','y','n','n','r'},
            {'n','y','y','n','n','y','n','y','y','n','y','n','?','?','?','?','d'},
            {'n','y','n','y','y','y','n','n','n','y','n','y','y','y','n','n','r'},
            {'n','y','y','n','?','y','y','y','y','y','y','n','n','?','n','?','d'},
            {'n','y','n','n','y','y','n','n','n','n','n','y','y','y','y','y','d'},
            {'n','n','n','n','y','y','y','n','n','n','n','y','y','y','n','y','d'},
            {'n','y','y','n','y','y','y','n','n','n','y','y','y','y','n','y','d'},
            {'n','y','n','y','y','y','y','n','n','n','n','y','y','y','n','y','r'},
            {'y','y','n','n','y','y','n','n','n','y','y','y','y','y','n','?','d'},
            {'n','y','y','n','n','y','y','y','y','y','y','n','y','n','y','?','d'},
            {'y','n','y','y','y','y','y','y','n','y','n','y','n','y','y','y','r'},
            {'y','n','y','y','y','y','y','y','n','y','y','y','n','y','y','y','r'},
            {'n','n','y','y','y','y','n','n','y','n','n','n','y','y','y','?','d'},
            {'y','n','y','n','n','n','y','y','y','y','y','n','n','y','n','y','d'},
            {'y','n','y','n','n','n','?','y','y','?','n','n','n','n','y','?','d'},
            {'n','?','n','y','y','y','n','n','n','y','n','y','y','y','n','y','r'},
            {'n','y','y','n','n','n','y','y','y','y','n','n','?','n','y','y','d'},
            {'n','n','n','n','y','y','n','n','n','y','y','y','y','y','n','y','d'},
            {'y','?','y','n','n','n','y','y','y','n','n','n','n','n','y','?','d'},
            {'n','y','y','n','n','n','y','y','y','y','n','n','n','n','y','y','d'},
            {'n','n','y','y','n','n','y','y','y','y','n','n','n','y','y','y','r'},
            {'n','n','y','n','n','n','y','y','y','y','y','?','n','n','y','y','d'},
            {'?','n','y','n','n','n','y','y','y','y','y','?','n','n','y','?','d'},
            {'y','n','y','n','n','n','y','y','y','y','n','n','n','n','y','y','d'},
            {'?','?','y','n','n','n','y','y','y','?','?','n','n','n','?','?','d'},
            {'n','n','y','n','n','n','y','y','y','y','y','n','n','n','y','y','d'},
            {'y','?','y','n','n','n','y','y','y','n','n','n','n','n','y','y','d'},
            {'?','?','?','?','?','?','?','?','y','?','?','?','?','?','?','?','d'},
            {'n','n','y','n','n','n','y','y','y','y','y','n','n','n','y','y','d'},
            {'y','n','y','n','n','n','y','y','y','y','n','?','n','n','y','y','d'},
            {'n','y','y','n','n','n','y','y','y','y','y','n','n','n','y','y','d'},
            {'y','n','y','n','n','n','y','y','y','n','n','n','n','n','y','?','d'},
            {'y','?','n','y','y','y','y','y','n','n','n','y','?','y','?','?','r'},
            {'y','n','y','n','n','n','y','y','y','n','n','n','n','n','y','y','d'},
            {'n','?','n','y','y','y','n','n','n','n','n','y','y','y','n','?','r'},
            {'n','y','n','y','y','y','n','?','n','y','n','y','y','y','n','?','r'},
            {'n','n','n','n','n','y','y','y','y','n','y','n','n','y','y','y','d'},
            {'n','n','y','n','n','n','y','y','y','n','n','n','n','n','y','y','d'},
            {'n','n','y','n','n','y','y','?','y','y','y','n','n','n','y','y','d'},
            {'n','n','n','y','y','y','n','n','n','n','n','y','y','y','n','?','r'},
            {'n','n','y','n','n','y','y','y','y','n','y','y','n','y','y','?','d'},
            {'n','?','y','y','y','y','n','n','n','y','n','n','n','y','n','y','r'},
            {'n','n','y','n','n','n','y','y','y','y','y','n','?','n','y','?','d'},
            {'y','y','n','n','n','n','y','y','?','n','y','n','n','n','y','?','d'},
            {'n','n','y','n','n','n','y','y','y','n','n','n','n','y','y','y','d'},
            {'y','y','y','n','n','n','y','y','y','n','n','n','n','n','y','y','d'},
            {'y','n','y','n','n','y','y','y','y','y','y','n','n','n','y','y','d'},
            {'y','n','y','n','n','n','y','y','y','y','n','n','n','n','y','y','d'},
            {'n','n','y','y','y','y','y','n','n','n','n','y','y','y','n','y','r'},
            {'n','n','y','n','n','y','y','y','y','y','n','y','n','n','n','y','d'},
            {'n','n','n','y','y','y','n','n','n','y','n','y','n','y','n','y','r'},
            {'y','?','n','y','y','y','y','n','n','y','n','y','y','y','n','y','r'},
            {'n','n','y','n','n','n','y','y','y','n','n','?','n','n','y','y','d'},
            {'y','y','y','n','n','n','y','y','y','y','y','n','n','n','n','y','d'},
            {'n','n','y','n','n','y','y','y','y','n','n','n','n','n','y','y','d'},
            {'n','y','n','y','y','y','n','n','n','y','n','y','y','y','n','y','r'},
            {'n','n','y','n','n','n','y','y','y','n','y','n','n','n','y','y','d'},
            {'n','y','y','n','n','y','n','y','y','n','y','n','y','n','y','y','d'},
            {'y','y','n','y','y','y','n','n','n','y','n','y','y','y','n','y','r'},
            {'n','y','y','y','y','y','n','n','n','y','y','y','y','y','y','?','d'},
            {'y','y','y','n','y','y','n','n','?','y','n','n','n','y','y','?','d'},
            {'n','y','n','y','y','y','n','n','n','y','n','y','y','y','n','n','r'},
            {'y','?','y','n','n','n','y','y','y','n','?','n','n','n','y','?','d'},
            {'n','y','y','n','n','n','n','y','y','n','y','n','n','y','y','y','d'},
            {'n','n','y','n','n','n','y','y','y','n','n','n','n','n','y','?','d'},
            {'n','y','y','n','y','y','n','n','n','n','y','n','n','n','y','?','d'},
            {'y','n','y','n','n','n','y','y','y','n','y','n','n','n','y','?','d'},
            {'n','n','n','y','y','n','n','n','n','n','n','y','y','y','n','y','r'},
            {'n','y','n','y','y','y','n','n','n','y','n','?','y','y','n','n','r'},
            {'n','?','n','y','y','y','n','n','n','n','n','y','y','y','n','y','r'},
            {'n','n','y','n','n','y','y','y','y','n','y','n','n','y','y','y','d'},
            {'y','n','y','n','n','n','y','y','y','n','n','n','n','n','?','y','d'},
            {'n','y','n','y','y','y','n','n','n','n','n','y','y','?','n','y','r'},
            {'n','y','y','y','y','y','y','n','y','y','n','y','y','y','n','y','r'},
            {'n','y','n','y','y','y','n','n','n','n','n','y','y','y','n','y','r'},
            {'n','y','n','y','y','y','n','n','y','y','n','y','y','y','n','y','r'},
            {'n','y','y','n','n','n','y','y','n','n','y','n','n','n','y','?','d'},
            {'n','y','n','y','y','y','n','n','n','y','n','y','y','y','n','y','r'},
            {'n','n','y','n','n','y','y','y','y','y','n','y','n','y','y','?','d'},
            {'n','n','n','y','y','y','n','n','n','y','n','y','n','y','n','y','r'},
            {'n','n','y','n','n','n','y','y','y','n','n','n','n','n','y','y','d'},
            {'y','n','y','n','n','y','y','y','n','n','n','y','y','n','n','y','d'},
            {'y','y','y','n','n','n','y','y','?','y','n','n','n','n','y','?','d'},
            {'n','n','n','y','y','y','y','n','n','y','n','n','n','y','y','y','r'},
            {'n','n','n','y','n','y','y','?','y','n','n','y','y','y','n','y','r'},
            {'y','n','y','n','n','n','y','y','y','y','y','n','n','y','y','y','d'},
            {'n','n','n','n','y','y','y','n','n','n','n','?','n','y','y','y','r'},
            {'n','y','y','n','n','n','y','y','?','y','n','n','y','n','y','y','d'},
            {'y','n','y','n','n','n','n','y','y','y','n','n','n','n','y','y','d'},
            {'y','n','y','n','n','n','y','y','y','y','y','n','n','n','y','y','d'},
            {'n','n','y','n','y','n','y','y','y','n','n','n','n','y','?','y','d'},
            {'n','y','n','y','y','y','?','n','n','n','n','?','y','y','n','n','r'},
            {'?','?','?','?','?','?','?','?','?','?','?','?','?','?','?','?','r'},
            {'y','n','y','n','n','n','y','y','?','n','y','n','n','n','y','y','d'},
            {'n','y','n','y','y','y','n','n','n','n','n','y','y','y','n','n','r'},
            {'n','y','n','y','y','y','n','n','n','n','n','y','y','y','n','n','r'},
            {'y','y','y','n','n','y','y','y','y','n','n','n','n','n','y','y','d'},
            {'n','y','n','y','y','y','n','n','n','n','n','y','y','y','n','y','r'},
            {'y','n','y','n','n','n','y','y','y','y','n','n','n','n','n','y','d'},
            {'y','n','y','n','n','n','y','y','y','y','n','n','n','y','y','y','d'},
            {'n','n','n','y','y','n','n','n','n','n','n','y','n','y','n','n','r'},
            {'n','n','n','y','y','n','n','n','n','n','n','y','n','y','?','y','r'},
            {'n','n','y','n','n','n','y','y','y','n','y','n','n','n','y','y','d'},
            {'y','n','y','n','n','n','y','y','y','n','n','n','n','n','n','y','d'},
            {'y','n','y','n','n','n','y','y','y','y','n','n','n','n','n','y','d'},
            {'y','n','y','n','n','?','y','y','y','n','?','?','n','?','?','?','d'},
            {'y','n','y','n','n','n','y','y','y','y','n','n','?','n','y','y','d'},
            {'y','n','y','n','n','n','y','y','y','n','n','n','n','n','y','?','d'},
            {'y','n','y','n','n','n','y','y','y','n','n','n','n','n','y','?','d'},
            {'y','n','y','n','n','n','y','y','y','y','n','n','n','n','n','y','d'},
            {'n','n','n','y','y','y','n','n','n','y','n','y','n','y','n','y','r'},
            {'y','n','n','n','n','n','y','y','y','y','n','n','n','y','n','y','r'},
            {'y','n','y','n','n','n','y','y','y','n','n','n','n','n','y','?','d'},
            {'y','n','y','n','n','n','y','y','y','n','n','n','n','n','n','y','d'},
            {'y','y','y','n','n','n','y','y','y','n','n','n','n','n','y','y','d'},
            {'n','y','y','n','n','y','y','y','y','n','?','n','n','n','n','y','d'},
            {'y','n','y','n','n','n','y','y','y','y','n','n','n','n','y','?','d'},
            {'n','n','n','y','y','n','y','y','n','y','n','y','y','y','?','y','r'},
            {'y','n','n','y','y','n','y','n','n','y','n','n','n','y','y','y','r'},
            {'n','n','y','n','y','y','n','n','n','n','?','n','y','y','n','n','d'},
            {'n','n','n','y','y','y','n','n','n','n','n','y','y','y','y','n','r'},
            {'n','n','y','y','y','y','y','y','n','y','n','n','n','y','n','y','r'},
            {'n','n','n','y','y','y','n','n','n','n','n','y','y','y','n','y','r'},
            {'n','n','n','y','y','y','n','n','n','y','n','y','y','y','n','n','r'},
            {'n','n','y','n','n','n','y','y','y','y','n','n','n','y','n','y','d'},
            {'y','n','y','y','y','y','y','y','n','n','n','n','n','y','n','?','r'},
            {'y','n','n','y','y','y','n','n','n','y','n','?','y','y','n','n','r'},
            {'n','n','n','y','y','y','n','n','n','n','n','y','y','y','n','y','r'},
            {'n','n','y','n','n','y','y','y','y','y','y','n','n','n','?','y','d'},
            {'n','n','y','n','n','y','y','y','y','y','y','n','n','n','y','y','d'},
            {'n','n','y','n','n','y','?','y','?','y','y','y','n','y','y','?','d'},
            {'y','y','y','?','n','y','y','y','y','n','y','n','y','n','?','y','d'},
            {'y','y','y','n','y','y','n','y','n','y','y','n','y','y','y','y','d'},
            {'y','y','y','n','y','y','n','y','n','y','y','n','y','y','n','?','d'},
            {'y','n','y','n','?','y','?','y','y','y','n','n','y','y','n','y','d'},
            {'y','n','y','n','n','y','y','y','y','y','n','?','n','y','n','y','d'},
            {'y','n','y','n','n','y','y','y','n','y','y','n','y','y','y','y','d'},
            {'y','y','y','n','n','y','y','y','y','y','y','n','y','y','y','y','d'},
            {'n','y','y','n','n','y','y','y','n','y','y','n','y','y','n','?','d'},
            {'n','y','n','y','y','y','?','?','n','y','n','y','?','?','?','?','r'},
            {'n','n','y','y','y','y','n','n','n','y','n','y','y','y','y','y','r'},
            {'y','y','y','n','n','y','y','y','y','y','n','n','?','n','y','?','d'},
            {'n','y','n','n','n','n','y','y','y','y','y','n','n','n','y','y','d'},
            {'n','y','y','n','n','y','y','y','y','y','n','n','y','y','y','y','d'},
            {'n','n','n','y','y','n','y','y','y','y','n','y','y','y','n','y','r'},
            {'n','n','?','n','n','y','y','y','y','n','n','n','n','n','y','y','d'},
            {'n','n','n','y','y','y','y','n','n','y','n','y','y','y','n','y','r'},
            {'n','n','n','y','y','y','n','n','n','n','n','y','y','y','n','n','r'},
            {'n','y','n','y','y','y','n','n','n','y','n','y','y','y','n','?','r'},
            {'n','n','n','y','y','y','n','n','n','y','n','y','y','y','n','n','r'},
            {'n','n','n','y','y','y','n','n','n','n','n','y','y','y','n','n','r'},
            {'y','n','y','n','n','y','y','y','y','n','n','n','n','y','n','?','d'},
            {'n','n','n','y','y','y','n','n','n','y','n','y','y','y','n','n','r'},
            {'y','n','n','n','n','y','y','y','y','y','n','n','n','y','y','y','d'},
            {'n','n','n','y','y','y','n','n','n','y','n','y','y','y','y','n','r'},
            {'n','n','y','n','n','y','y','y','y','y','n','n','y','n','n','y','d'},
            {'y','y','y','n','n','n','y','y','y','y','n','n','n','n','y','y','d'},
            {'n','y','y','y','y','y','n','n','n','y','n','y','y','y','n','y','r'},
            {'n','y','n','y','y','y','y','y','n','n','y','y','y','y','y','y','r'},
            {'n','y','y','y','y','y','y','?','n','n','n','n','?','?','y','?','r'},
            {'n','n','n','n','n','y','n','y','y','n','y','y','y','y','y','n','d'},
            {'y','n','n','n','n','n','y','y','y','y','n','n','n','n','y','y','d'},
            {'n','n','y','n','n','n','y','y','y','n','n','n','n','n','y','?','d'},
            {'y','n','y','n','n','n','y','y','y','n','n','n','n','n','y','?','d'},
            {'n','y','y','n','n','y','n','y','y','y','n','n','y','y','n','y','d'},
            {'y','y','y','n','n','n','y','y','y','y','n','n','y','n','n','y','d'},
            {'y','y','y','n','?','y','n','?','n','n','y','n','y','y','n','?','d'},
            {'y','y','y','n','y','y','n','y','?','y','n','n','y','y','n','?','d'},
            {'n','y','n','y','y','y','n','n','n','n','y','y','y','y','n','n','r'},
            {'n','y','n','n','y','y','n','n','?','n','n','y','y','y','n','y','d'},
            {'y','y','n','y','n','n','y','y','y','n','y','n','n','y','n','y','d'},
            {'n','y','n','y','y','y','n','n','n','n','n','y','y','y','n','y','r'},
            {'y','y','y','n','n','n','y','y','y','n','y','n','n','n','n','y','d'},
            {'y','?','y','n','n','y','y','y','y','y','n','n','n','n','y','?','d'},
            {'n','y','n','y','y','y','n','n','n','y','n','y','y','y','n','n','r'},
            {'y','?','y','n','n','n','y','y','y','n','n','n','n','n','y','?','d'},
            {'y','n','y','n','n','n','y','y','y','n','y','n','n','n','y','?','d'},
            {'n','n','y','n','n','n','y','y','y','n','n','n','n','n','y','y','d'},
            {'n','y','y','n','n','y','y','y','?','n','y','y','n','n','y','y','d'},
            {'n','n','n','y','y','y','n','n','n','y','y','y','y','y','n','?','r'},
            {'n','n','y','n','n','y','y','y','n','n','y','n','n','y','?','y','d'},
            {'y','n','y','n','n','n','y','y','y','n','n','n','n','n','y','y','d'},
            {'y','n','y','n','n','n','y','y','y','y','n','n','n','y','y','y','d'},
            {'y','n','n','y','y','y','n','n','n','n','y','y','y','y','n','n','r'},
            {'n','n','n','y','y','y','n','n','n','y','y','y','n','y','n','y','r'},
            {'n','?','y','?','n','y','y','y','y','y','y','n','?','?','y','y','d'},
            {'n','y','y','n','y','?','y','n','n','y','y','n','y','n','y','y','d'},
            {'n','n','n','y','y','n','y','n','y','y','n','n','n','y','n','y','r'},
            {'n','n','y','n','n','n','y','y','y','y','y','n','n','n','y','y','d'},
            {'n','n','n','y','y','y','y','n','n','y','n','y','n','y','y','y','r'},
            {'n','n','n','y','y','y','n','n','n','y','n','y','y','y','n','y','r'},
            {'y','n','n','y','y','y','n','n','n','y','n','y','y','y','n','n','r'},
            {'y','n','y','n','n','n','y','y','y','y','n','y','n','n','y','?','d'},
            {'n','y','y','y','y','y','y','y','y','n','n','y','y','y','n','y','r'},
            {'n','y','n','n','n','y','y','n','y','n','y','n','n','n','y','y','d'},
            {'n','n','y','y','y','y','y','y','y','y','n','y','y','y','y','y','r'},
            {'n','y','n','y','n','y','y','y','y','n','y','n','y','n','y','?','d'},
            {'n','n','y','y','y','y','y','n','n','y','y','y','y','y','n','y','r'},
            {'n','y','y','n','n','y','y','y','y','y','n','?','n','n','y','y','d'},
            {'y','n','y','y','n','n','n','y','y','y','n','n','n','y','y','y','r'},
            {'n','n','n','y','y','y','n','n','n','n','n','y','y','y','n','n','r'},
            {'n','n','n','y','y','y','n','n','n','n','n','y','y','y','n','n','r'},
            {'y','y','y','n','n','y','y','y','y','y','y','y','y','y','n','?','d'},
            {'n','n','n','y','y','y','n','n','n','y','?','y','y','y','n','y','r'},
            {'y','n','y','n','n','y','y','y','y','y','n','n','y','n','n','y','d'},
            {'y','n','y','n','y','y','y','n','y','y','n','n','y','y','n','?','d'},
            {'y','y','y','n','n','y','y','y','y','y','y','y','y','n','n','y','d'},
            {'y','y','n','y','y','y','n','n','n','y','y','n','y','n','n','n','r'},
            {'y','y','n','y','y','y','n','n','n','n','y','n','y','y','n','y','r'},
            {'n','y','n','n','y','y','n','n','n','y','y','n','y','y','n','n','d'},
            {'y','n','y','n','n','n','y','y','n','y','y','n','n','n','n','?','d'},
            {'y','y','y','n','y','y','y','y','n','y','y','n','n','n','y','?','d'},
            {'n','y','y','n','n','y','y','y','n','y','n','n','n','n','y','y','d'},
            {'n','y','n','y','y','y','n','n','n','n','n','n','y','y','n','y','r'},
            {'y','y','y','n','?','y','y','y','n','y','?','?','n','n','y','y','d'},
            {'y','y','y','n','?','n','y','y','y','y','n','n','n','n','y','?','d'},
            {'n','y','y','y','y','y','n','n','n','n','y','y','?','y','n','n','d'},
            {'n','y','y','?','y','y','n','y','n','y','?','n','y','y','?','y','d'},
            {'n','y','n','y','y','y','n','n','n','n','n','y','y','y','n','y','r'},
            {'n','y','n','y','y','y','n','n','n','n','y','y','n','y','n','n','d'},
            {'y','?','y','n','n','n','y','y','y','n','y','n','n','n','y','y','d'},
            {'n','y','n','y','y','y','?','?','n','n','?','?','y','?','?','?','r'},
            {'n','n','n','y','y','y','n','n','n','n','n','y','y','y','n','y','r'},
            {'n','n','n','y','y','y','n','n','n','n','n','y','y','y','n','y','r'},
            {'y','y','y','n','n','y','?','y','y','n','y','n','y','n','y','y','d'},
            {'y','y','y','n','y','y','y','y','y','y','y','n','y','y','n','?','d'},
            {'y','y','n','y','y','y','n','n','n','n','y','n','y','y','n','?','d'},
            {'y','y','y','n','y','y','n','y','y','y','y','n','n','n','n','y','d'},
            {'y','y','y','y','y','y','n','n','n','n','y','y','y','y','n','y','d'},
            {'y','y','n','n','y','y','n','n','n','n','y','y','y','y','y','n','d'},
            {'n','?','y','n','y','y','n','y','n','n','y','n','n','n','n','?','d'},
            {'y','y','y','n','y','y','n','y','y','n','y','n','n','y','n','?','d'},
            {'n','y','y','y','y','y','n','n','n','n','n','y','y','y','n','?','d'},
            {'y','n','y','n','n','n','y','y','y','?','y','n','n','n','y','?','d'},
            {'?','?','n','n','?','y','?','n','n','n','y','y','n','y','n','?','d'},
            {'y','y','n','n','n','n','n','y','y','n','y','n','n','n','y','n','d'},
            {'y','y','n','y','y','y','n','n','n','n','y','y','y','y','n','y','r'},
            {'?','?','?','?','n','y','n','y','y','n','n','y','y','n','n','?','r'},
            {'y','y','?','?','?','y','n','n','n','n','y','n','y','n','n','y','d'},
            {'y','y','y','?','n','n','n','y','n','n','y','?','n','n','y','y','d'},
            {'y','y','y','n','y','y','n','y','n','n','y','n','y','n','y','y','d'},
            {'y','y','n','n','y','?','n','n','n','n','y','n','y','y','n','y','d'},
            {'n','y','y','n','y','y','n','y','n','n','n','n','n','n','n','y','d'},
            {'n','y','n','y','?','y','n','n','n','y','n','y','y','y','n','n','r'},
            {'n','y','n','y','y','y','n','?','n','n','?','?','?','y','n','?','r'},
            {'n','y','n','y','y','y','n','n','n','y','y','y','y','y','n','n','r'},
            {'?','n','y','y','n','y','y','y','y','y','n','y','n','y','n','y','r'},
            {'n','y','n','y','y','y','n','n','n','y','n','y','?','y','n','n','r'},
            {'y','y','n','y','y','y','n','n','n','y','n','y','y','y','n','y','r'},
            {'n','n','n','y','y','y','n','n','n','n','n','y','y','y','n','y','r'},
            {'y','n','y','n','y','y','n','n','y','y','n','n','y','y','n','y','d'},
            {'n','n','n','y','y','y','n','n','n','n','y','y','y','y','n','n','d'},
            {'y','n','y','n','n','y','y','y','y','n','n','y','?','y','y','y','d'},
            {'n','n','n','y','y','y','n','n','n','n','n','y','y','y','n','n','r'},
            {'n','n','n','y','y','y','n','n','n','n','y','y','y','y','n','y','r'},
            {'y','n','y','n','n','y','y','y','y','y','y','n','n','n','n','y','d'},
            {'n','n','n','y','y','y','n','n','n','y','n','y','y','y','n','y','r'},
            {'y','y','y','y','y','y','y','y','n','y','?','?','?','y','n','y','r'},
            {'y','y','y','n','n','n','y','y','y','n','n','n','n','n','n','y','d'},
            {'n','y','y','n','n','y','y','y','?','y','n','n','n','n','n','y','d'},
            {'y','y','n','y','y','y','n','n','n','y','n','n','y','y','n','y','r'},
            {'y','y','y','n','n','n','y','y','y','y','y','n','y','n','n','y','d'},
            {'y','y','y','n','n','n','y','y','n','y','n','n','n','n','n','y','d'},
            {'y','y','y','n','n','n','y','y','y','n','n','n','n','n','n','y','d'},
            {'y','y','y','y','y','y','y','y','n','y','n','n','y','y','n','y','r'},
            {'n','y','y','n','y','y','y','y','n','n','y','n','y','n','y','y','d'},
            {'n','n','y','n','n','y','y','y','y','n','y','n','n','n','y','y','d'},
            {'n','y','y','n','n','y','y','y','y','n','y','n','n','y','y','y','d'},
            {'n','y','y','n','n','?','y','y','y','y','y','n','?','y','y','y','d'},
            {'n','n','y','n','n','n','y','y','n','y','y','n','n','n','y','?','d'},
            {'y','n','y','n','n','n','y','y','y','y','n','n','n','n','y','y','d'},
            {'n','n','n','y','y','y','y','y','n','y','n','y','y','y','n','y','r'},
            {'?','?','?','n','n','n','y','y','y','y','n','n','y','n','y','y','d'},
            {'y','n','y','n','?','n','y','y','y','y','n','y','n','?','y','y','d'},
            {'n','n','y','y','y','y','n','n','y','y','n','y','y','y','n','y','r'},
            {'n','n','y','n','n','n','y','y','y','y','n','n','n','n','n','y','d'},
            {'n','?','n','y','y','y','n','n','n','n','y','y','y','y','n','y','r'},
            {'n','n','n','y','y','y','?','?','?','?','n','y','y','y','n','y','r'},
            {'n','y','n','y','y','y','n','n','n','y','n','y','y','y','?','n','r'}
        };
    }
}