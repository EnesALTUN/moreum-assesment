<h1>Assignment</h1>
<p>Please create a simple application with the specifications below. The product should be a basic document generator with template support.</p>
<ul>
<li>You are free to choose the language and the technology you are comfortable with.</li>
<li>You can write a desktop, console or web application.</li>
<li>The application must use a single template file. The template must not be hard-coded. Example template is given below.</li>
<li>App must accept a CSV data file from the user. Example below.</li>
<li>App must read all the lines from the CSV file and parse the data.</li>
<li>For every line in the data file, app must fill the placeholders in the template file and create a separate document and save it on the disk.</li>
<li>App must not assume hard-coded folder paths or file names. For these, user input or configuration files are acceptable solutions.</li>
<li>App should not crash or display unhandled error messages for missing or invalid data. Any errors should be reported to the user in a friendly way.</li>
<li>App should not have issues with Turkish characters in the template or data (support UTF-8).</li>
<li>Ideally, user should be able to compile and run the application without making changes to source code.</li>
</ul>
<h2>Template File</h2>
<p>The template file is the empty text document with placeholders for data fields. An example is given below. This template can be packed along with the source code, but it must not be hard-coded into the program. Any changes to the template should not break the program. This includes changing of fixed text or removal of placeholders.</p>
<pre><code>Konu: {TARIH} tarihli faturanız.

Sayın {AD} {SOYAD},
{FATURANO} numaralı hizmet faturanız ekte gönderilmiştir. 
Bu dönem için fatura tutarınız: {TUTAR} TL.

Saygılarımızla,
</code></pre>

<p>The words in brackets are placeholders. The app must replace these with the data extracted from the data files, except for the {TARIH} field. This field must be filled with the current date. </p>
<p>If there are unrecognized placeholders in the template file, they should be ignored.</p>
<h2>Data File</h2>
<p>The data file contains the field values: One line for each customer. It is a CSV (comma separated value) file saved from Excel:</p>
<pre><code>123456;Ahmet;Cingöz;34
234567;Ali Fuat;Bilge;45
345678;Ayla;Kaplan;19
456789;Süheyla ;Akça Oğul;72
</code></pre>

<p>Format of the data file is fixed. Each line contains four fields, separated with semicolons. The fields are FATURANO, AD, SOYAD and TUTAR in order.</p>
<h2>Expected Output</h2>
<p>Your app should read the data file, merge the fields into the template and create a separate output file for every line. FATURANO must be used for the filename and the extensions must be TXT. For the example above, your app should create four files:</p>
<pre><code>123456.txt
234567.txt
345678.txt
456789.txt
</code></pre>

<p>Each output file must contain text merged from the template file. For example, <strong>456789.txt</strong> file must contain the following:</p>
<pre><code>Konu: 15.10.2014 tarihli faturanız.

Sayın Süheyla Akça Oğul,
456789 numaralı hizmet faturanız ekte gönderilmiştir. 
Bu dönem için fatura tutarınız: 72 TL.

Saygılarımızla,
</code></pre>

<p>Your app must not assume that data file will contain four lines. App must be able to handle data files with only one line or a hundred lines.</p>
<p>Your app must not crash if the format of the data file is incorrect. Instead, it should try to display appropriate warnings to the user.</p>
<h2>Notes</h2>
<ul>
<li>Sample template and data files are provided with this document. These files are saved with UTF-8 encoding. </li>
<li>Keep in mind that your application will be tested with different templates (with similar format) and data files (both valid and invalid).</li>
<li>You can use code snippets found on Internet, but you must put reference comments above them, including the source web address. Also, make sure you have a thorough understanding of such code because you may be asked to explain or modify your code for a final evaluation.</li>
<li>Commented and clean code is always a plus.</li>
<li>Unexpected compilation or runtime errors are always a minus.</li>
<li>You can add extra useful features not specified in this document. These too will be considered a plus.</li>
</ul>
