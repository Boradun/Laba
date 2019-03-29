using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba
{
    static class Control
    {
        
        static Hero _hero;
        static Labirinth laba;

        static internal void InitializeControl()
        {
            _hero = new Hero(10);
            laba = new Labirinth(_hero.Level);
            Draw.DrawBackgroundImage(laba, _hero.Level);
            Draw.ReDrawHero(_hero.HeroPositionX, _hero.HeroPositionY, _hero.HeroPositionX, _hero.HeroPositionY, _hero.Level);
        }
        static internal void DoMove(Keys key)
        {
            switch (key)
            {
                case Keys.Up:
                    {
                        if (_hero.HeroPositionY>0 && laba.GeneratedLabirint[_hero.HeroPositionX,_hero.HeroPositionY-1]!=Labirinth.CellType.wall)
                        {
                            Draw.ReDrawHero(_hero.HeroPositionX,_hero.HeroPositionY,_hero.HeroPositionX,--_hero.HeroPositionY,_hero.Level);
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        if (_hero.HeroPositionY < _hero.Level*2-2 && laba.GeneratedLabirint[_hero.HeroPositionX , _hero.HeroPositionY+1] != Labirinth.CellType.wall)
                        {
                            Draw.ReDrawHero(_hero.HeroPositionX, _hero.HeroPositionY, _hero.HeroPositionX, ++_hero.HeroPositionY, _hero.Level);
                        }
                        break;
                    }
                case Keys.Right:
                    {
                        if (_hero.HeroPositionX < _hero.Level * 2-2 && laba.GeneratedLabirint[_hero.HeroPositionX+1, _hero.HeroPositionY ] != Labirinth.CellType.wall)
                        {
                            Draw.ReDrawHero(_hero.HeroPositionX, _hero.HeroPositionY, ++_hero.HeroPositionX, _hero.HeroPositionY, _hero.Level);
                        }
                        break;
                    }
                case Keys.Left:
                    {
                        if (_hero.HeroPositionX >0 && laba.GeneratedLabirint[_hero.HeroPositionX-1, _hero.HeroPositionY ] != Labirinth.CellType.wall)
                        {
                            Draw.ReDrawHero(_hero.HeroPositionX, _hero.HeroPositionY, --_hero.HeroPositionX, _hero.HeroPositionY, _hero.Level);
                        }
                        break;
                    }
            }
        }
    }
}
