import multiprocessing
import threading

import pika
import time

def callback(ch, method, properties, body):
  print(" [x] Received %r" % body)

def publish(channel):
  #channel.queue_declare(queue='PythonToCsharp')
  count = 0
  while(True):
    channel.basic_publish(exchange='',
                        routing_key='PythonToCsharp',
                        body=f"Hi 3omda from python! \t count : {count}")
    count+=1
    time.sleep(3)

def consume(channel):
  channel.basic_consume('CsharpToPython',
                        callback,
                        auto_ack=True)

  print(' [*] Waiting for messages:')
  channel.start_consuming()

connection = pika.BlockingConnection(
    pika.ConnectionParameters(host='localhost')
)
ch = connection.channel()

publish_process = threading.Thread(target=publish,args=(ch,)).start()
consume_process = threading.Thread(target=consume,args=(ch,)).start()
