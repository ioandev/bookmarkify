﻿using bookmarkify.Models;
using System;
using System.Text.RegularExpressions;

namespace bookmarkify
{
    public class VoiceBookmarkMetadataConverter
    {
        public BookmarkMetadata Convert(string bookmarkTxt)
        {
            Regex regex = new Regex(@"\*\*\* \[.*?\] (\d), \d+");
            Match match = regex.Match(bookmarkTxt);

            if (match.Groups.Count != 2)
            {
                throw new InvalidOperationException("Regex has changed.");
            }

            string colour = match.Groups[1].Value;
            int colourInt = int.Parse(colour);

            return new BookmarkMetadata
            {
                Colour = (HighlightType)colourInt
            };
        }
    }
}