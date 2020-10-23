const execSync = require('child_process').execSync;
const fs = require('fs');

if (!fs.existsSync('.release')) {
  console.log('No in progress release found');
  process.exit(0);
}

const tmp = fs.readFileSync('.release');

if (fs.existsSync(tmp)) {
  execSync(`rm -r ${tmp}`, { stdio: 'inherit' });
}

execSync(`rm -r .release`, { stdio: 'inherit' });