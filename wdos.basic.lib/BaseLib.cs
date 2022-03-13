namespace wdos.basic.lib
{
    public class BaseLib
    {

        /// <summary>
        /// 生成指定数量的字符
        /// </summary>
        /// <param name="num">数量</param>
        /// <param name="c">字符</param>
        /// <returns>拼合成字符串</returns>
        private static string GenerateChar(int num, char c)
        {
            string space = "";
            for (int i = 0; i < num; i++) space += c;
            return space;
        }
    }
}