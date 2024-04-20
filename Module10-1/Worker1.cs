using Module10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Module10_1
{
    public class Worker1 : IWorker //реализовываем интерфес айвокер
    {
        ILogger Logger { get; } //переменная логгер с модификатором гет
        public Worker1(ILogger logger) //конструктор с параметром интерфес айлоггер
        {
            Logger = logger;
        }

        public void Work()//сообщает в логгер что произошло какоето событие
        {
            Logger.Event("Worker 1 начал свою работу");//обращаемся в логгер и выполняем наш евент
            Thread.Sleep(3000);//задержка в 3 секунды
            Logger.Event("Worker 1 окончил свою работу");
        }
    }

    public class Worker2 : IWorker //реализовываем интерфес айвокер
    {
        ILogger Logger { get; } //переменная логгер с модификатором гет
        public Worker2(ILogger logger) //конструктор с параметром интерфес айлоггер
        {
            Logger = logger;
        }

        public void Work()
        {
            Logger.Event("Worker 2 начал свою работу");
            Thread.Sleep(3000);
            Logger.Event("Worker 2 окончил свою работу");
        }
    }

    public class Worker3 : IWorker //реализовываем интерфес айвокер
    {
        ILogger Logger { get; } //переменная логгер с модификатором гет
        public Worker3(ILogger logger) //конструктор с параметром интерфес айлоггер
        {
            Logger = logger;
        }

        public void Work()
        {
            Logger.Event("Worker 3 начал свою работу");
            Thread.Sleep(3000);
            Logger.Event("Worker 3 окончил свою работу");
        }
    }
}
