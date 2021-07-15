using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLesson.DessignPattern.Adapter
{
    class Adapter1
    {
        /*
        適配器模式
        (想像成轉接頭)

        ex: A 類 的m1 方法  想調用 B類m2 方法，但因為種種原因(參數不匹配)，無法調用
        => 中間加個適配器類 A=>調用適配器的類=>B 對於A來說很像透明的直接使用B

        基本介紹:
        1. 將某類的接口轉換成客戶端期望的樣子表示，屬於結構型的(沒有新的對像產生)

        2. 可分為三類

           (1) 類適配器

           (2) 對像適配器

           (3) 接口適配器

        3. 工作原理
        
           (1) 將原本的類轉換成另一種接口，讓原本不兼容的類可以兼容

           (2) 對使用者來說看不到被適配者，是解偶的

           (3) 用戶調用 => 被適配器轉化出來的接口方法 => 是配器在去調用被適配者的相關接口

        4. 角色

           (1) Target(最終輸出的目標)dst

           (2) Adapter(適配器)

           (3) Src(被適配者)
           
         
        */
    }
}
