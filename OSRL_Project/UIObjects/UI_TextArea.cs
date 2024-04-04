using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;

public enum TextAlignmentHorizontal
{
	left, center, right
}
public enum TextAlignmentVertical
{
	top, middle, bottom
}

public class UI_TextArea : UIObject
{
	#region Constructors

	public UI_TextArea(string name, int x, int y, int width, int height,
		string text) 
		: base(name, x, y, width, height)
	{
		Text = text;
	}
	#endregion
	string Text;
	public TextAlignmentHorizontal AlignmentHorizontal = TextAlignmentHorizontal.left;
	public TextAlignmentVertical AlignmentVertical = TextAlignmentVertical.top;

	public override void Draw()
	{
		Rect rect = GetRect();
		int stringIndex = 0;
		string toUse = Text;
		if (IsFocused)
		{
			toUse = ">" + Text;
		}

		// Inspiration from
		// https://stackoverflow.com/questions/10541124/wrap-text-to-the-next-line-when-it-exceeds-a-certain-length        
		string[] words = toUse.Split(' ');

		string text = "";
		int limit = rect.Width;
		foreach (string word in words)
		{
			if (word.Length > limit)
			{
				int timesWrapped = word.Length / limit;
				limit += rect.Width * timesWrapped;
			}
			else if ((text + word).Length > limit)
			{
				int max = text.Length;
				for (int i = 0; i < (limit) - max; i++)
				{
				  text += " ";  
				}
				//sentence.Add(line);
				//line = "";
				limit += rect.Width;
			}

			if (text.Length + word.Length + 1 > limit || word == words[words.Length-1])
			{
				text += word;
			}
			else
			{
				text += word + " ";
			}
			//line += string.Format("{0} ", word);
		}

		// if (line.Length > 0)
		// {
		//     sentence.Add(line);
		// }

		

		int height = rect.Height;
		int textHeight = text.Length / rect.Width;
		
			int initialY = 0; // AlignmentVertical == TextAlignmentVertical.top
			if (AlignmentVertical == TextAlignmentVertical.middle)
			{
				initialY = ((height-1) / 2) - (textHeight / 2);
			}
			else if (AlignmentVertical == TextAlignmentVertical.bottom)
			{
				initialY = (height-1) - (textHeight);
			}

			for (int y = initialY; y < rect.Height; y++)
			{
				// TODO - get size of line with trailing whitespaces removed, push center / right based on

				int initialX = 0; //AlignmentHorizontal == TextAlignmentHorizontal.top
				if (AlignmentHorizontal == TextAlignmentHorizontal.center)
				{
					
				}
				else if (AlignmentHorizontal == TextAlignmentHorizontal.right)
				{
					
				}

			
				for (int x = 0; x < rect.Width; x++)
				{
					if (stringIndex < text.Length)
					{
						DisplayManager.Draw(x + rect.X, y + rect.Y, text[stringIndex], GetColorForeground(), GetColorBackground());
						stringIndex += 1;
					}
				}
			}




		if (AlignmentHorizontal == TextAlignmentHorizontal.left)
		{       
			
		}   
		else if (AlignmentHorizontal == TextAlignmentHorizontal.left && AlignmentVertical == TextAlignmentVertical.top)
		{

		}  
		base.Draw();
	}
}