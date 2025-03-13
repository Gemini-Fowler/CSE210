using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>()
    {
        "What is one thing I learned today?",
        "How did I make someone else's day better today?",
        "What is one small moment of joy I experienced today?",
        "What is something I did today that brought me closer to my goals?",
        "What is one thing I am grateful for today?"
    };

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(_prompts.Count);
        return _prompts[index];
    }
}
